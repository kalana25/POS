using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using POS.Core.General;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Items.PaginatedItems
{
    public class PaginatedItemsUsecase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedItemsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<ItemInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.Items.GetPagination(RequestData);
            IEnumerable<ItemInfoDto> result = mapper.Map<IEnumerable<Item>, IEnumerable<ItemInfoDto>>(respond.Items);
            return new ResponseData<ItemInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
