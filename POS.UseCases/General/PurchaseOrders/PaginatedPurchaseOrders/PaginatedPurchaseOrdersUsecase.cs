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

namespace POS.UseCases.General.PurchaseOrders.PaginatedPurchaseOrders
{
    public class PaginatedPurchaseOrdersUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedPurchaseOrdersUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<PoHeaderInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.PurchaseOrders.GetPagination(RequestData);
            IEnumerable<PoHeaderInfoDto> result = mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PoHeaderInfoDto>>(respond.Items);
            return new ResponseData<PoHeaderInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
