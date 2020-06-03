using System.Threading.Tasks;
using POS.Repositories;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.PurchaseUnits.DeletePurchaseUnit
{
    public class DeletePurchaseUnitUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeletePurchaseUnitUsecase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            PurchaseUnit unit = await unitOfWork.PurchaseUnits.Get(Id);
            unitOfWork.PurchaseUnits.Remove(unit);
            return await unitOfWork.Complete();
        }
    }
}
