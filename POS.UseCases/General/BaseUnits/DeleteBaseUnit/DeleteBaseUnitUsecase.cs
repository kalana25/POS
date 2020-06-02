using System.Threading.Tasks;
using POS.Repositories;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.BaseUnits.DeleteBaseUnit
{
    public class DeleteBaseUnitUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeleteBaseUnitUsecase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            BaseUnit unit = await unitOfWork.BaseUnits.Get(Id);
            unitOfWork.BaseUnits.Remove(unit);
            return await unitOfWork.Complete();
        }
    }
}
