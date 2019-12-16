using System.Threading.Tasks;
using POS.Repositories;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.Items.DeleteItem
{
    public class DeleteItemUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeleteItemUsecase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            Item item = await unitOfWork.Items.Get(Id);
            unitOfWork.Items.Remove(item);
            return await unitOfWork.Complete();
        }
    }
}
