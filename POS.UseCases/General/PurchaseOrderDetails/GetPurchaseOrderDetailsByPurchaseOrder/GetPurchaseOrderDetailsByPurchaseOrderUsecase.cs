using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System.Collections;
using POS.UseCases.DTO.Supplier;

namespace POS.UseCases.General.PurchaseOrderDetails.GetPurchaseOrderDetailsByPurchaseOrder
{
    public class GetPurchaseOrderDetailsByPurchaseOrderUsecase:UseCase
    {
        public int PurchaseOrderId { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public GetPurchaseOrderDetailsByPurchaseOrderUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PoDetailInfoWithItemDto>> Execute()
        {
            IEnumerable<PurchaseOrderDetail> list = await unitOfWork.PurchaseOrderDetails.GetPurchaseOrderDetailsWithFullInfo(this.PurchaseOrderId);
            var result = mapper.Map<IEnumerable<PurchaseOrderDetail>, IEnumerable<PoDetailInfoWithItemDto>>(list);
            return result;
        }
    }
}
