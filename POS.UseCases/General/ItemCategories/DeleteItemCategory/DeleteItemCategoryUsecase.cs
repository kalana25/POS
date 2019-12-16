using System.Threading.Tasks;
using POS.Repositories;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.ItemCategories.DeleteItemCategory
{
    public class DeleteItemCategoryUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeleteItemCategoryUsecase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            ItemCategory itemCategory = await unitOfWork.ItemCategories.Get(Id);
            unitOfWork.ItemCategories.Remove(itemCategory);
            return await unitOfWork.Complete();
        }
    }
}
