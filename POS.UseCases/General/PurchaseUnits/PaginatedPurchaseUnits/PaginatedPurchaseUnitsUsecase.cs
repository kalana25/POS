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

namespace POS.UseCases.General.PurchaseUnits.PaginatedPurchaseUnits
{
    public class PaginatedPurchaseUnitsUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedPurchaseUnitsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<PurchaseUnitInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.PurchaseUnits.GetPagination(RequestData);
            IEnumerable<PurchaseUnitInfoDto> result = mapper.Map<IEnumerable<PurchaseUnit>, IEnumerable<PurchaseUnitInfoDto>>(respond.Items);
            return new ResponseData<PurchaseUnitInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
