using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.PurchaseOrders.GetNextPurchaseOrderCode
{
    public class GetNextPurchaseOrderCodeUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextPurchaseOrderCodeUsecase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Execute()
        {
            PurchaseOrder purchaseOrder = await unitOfWork.PurchaseOrders.GetLastPurchaseOrder();
            if (purchaseOrder != null)
            {
                int nextId = purchaseOrder.Id;
                nextId += 1;
                string result = nextId.ToString().PadLeft(4, '0');
                return $"PU{result}";
            }
            return "PU0001";
        }
    }
}
