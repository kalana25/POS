using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.ItemCategories.GetNextItemCategoryCode
{
    public class GetNextItemCategoryCodeUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextItemCategoryCodeUsecase(IUnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public async Task<string> Execute()
        {
            int itemCategoryId = await unitOfWork.ItemCategories.GetLastItemCategoryId();
            int nextId = itemCategoryId;
            nextId += 1;
            string result = nextId.ToString().PadLeft(4, '0');
            return $"CT{result}";
        }
    }
}
