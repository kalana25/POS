using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;


namespace POS.UseCases.General.PurchaseOrders.GetPurchaseOrders
{
    public class GetPurchaseOrdersUsecase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetPurchaseOrdersUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PoHeaderInfoDto>> Execute()
        {
            IEnumerable<PurchaseOrder> purchaseOrders = await unitOfWork.PurchaseOrders.GetAll();
            IEnumerable<PoHeaderInfoDto> result = mapper.Map<IEnumerable<PurchaseOrder>, IEnumerable<PoHeaderInfoDto>>(purchaseOrders);
            return result;
        }
    }
}
