using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.ItemCategories.UpdateItemCategory
{
    public class UpdateItemCategoryUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public ItemCategorySaveDto Dto { get; set; }

        public UpdateItemCategoryUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            ItemCategory itemCategory = await unitOfWork.ItemCategory.Get(Id);
            mapper.Map<ItemCategorySaveDto, ItemCategory>(Dto, itemCategory);
            return await unitOfWork.Complete();
        }
    }
}
