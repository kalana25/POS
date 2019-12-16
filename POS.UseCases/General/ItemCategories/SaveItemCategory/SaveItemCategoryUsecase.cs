using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.ItemCategories.SaveItemCategory
{
    public class SaveItemCategoryUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ItemCategorySaveDto Dto { get; set; }

        public SaveItemCategoryUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ItemCategory> Execute()
        {
            ItemCategory itemCategory = mapper.Map<ItemCategorySaveDto, ItemCategory>(Dto);
            unitOfWork.ItemCategories.Add(itemCategory);
            await unitOfWork.Complete();
            return itemCategory;
        }


    }
}
