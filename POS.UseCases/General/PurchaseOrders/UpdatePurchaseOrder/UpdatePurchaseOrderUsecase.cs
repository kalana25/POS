using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System;

namespace POS.UseCases.General.PurchaseOrders.UpdatePurchaseOrder
{
    public class UpdatePurchaseOrderUsecase : UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public PurchaseOrderUpdateDto Dto { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public UpdatePurchaseOrderUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PoHeaderInfoDto> Execute()
        {
            //update status of the old purchase order.
            var purchaseOrder = await unitOfWork.PurchaseOrders.GetPurchaseOrderWithDetails(Id);
            purchaseOrder.Status = Models.Enums.PoStatus.Modified;
            //create a new po with reference no (RefNo = previous purchase order's Id)
            PurchaseOrder newHeader = mapper.Map<PurchaseOrderUpdateDto, PurchaseOrder>(Dto);
            newHeader.Status = Models.Enums.PoStatus.Pending;
            newHeader.CreatedOn = DateTime.Now;
            newHeader.CreatedBy = CreatedBy;
            newHeader.CreatedByName = CreatedByName;
            newHeader.ReferenceId = purchaseOrder.Id;

            List<PurchaseOrderDetail> details = mapper.Map<List<PurchaseOrderSaveDetail>, List<PurchaseOrderDetail>>(Dto.Items);
            newHeader.Items = details;
            unitOfWork.PurchaseOrders.Add(newHeader);
            await unitOfWork.Complete();
            var headerDto = this.mapper.Map<PurchaseOrder, PoHeaderInfoDto>(newHeader);
            return headerDto;
        }
    }
}
