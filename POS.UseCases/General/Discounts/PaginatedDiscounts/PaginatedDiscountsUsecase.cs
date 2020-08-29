using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.Core.General;
using POS.Models;
using POS.Core.Interfaces;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Discounts.PaginatedDiscounts
{
    public class PaginatedDiscountsUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedDiscountsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<DiscountInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.Discounts.GetPagination(RequestData);
            IEnumerable<DiscountInfoDto> result = mapper.Map<IEnumerable<Discount>, IEnumerable<DiscountInfoDto>>(respond.Items);
            return new ResponseData<DiscountInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
