using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.PurchaseOrders.DeletePurchaseOrder
{
    public class DeletePurchaseOrderDeleteUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeletePurchaseOrderDeleteUsecase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            var purchaseOrder = await unitOfWork.PurchaseOrders.GetPurchaseOrderWithDetails(Id);
            unitOfWork.PurchaseOrderDetails.RemoveRange(purchaseOrder.Items);
            unitOfWork.PurchaseOrders.Remove(purchaseOrder);
            return await unitOfWork.Complete();
        }
    }
}
