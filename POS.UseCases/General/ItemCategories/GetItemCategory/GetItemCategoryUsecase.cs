using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.ItemCategories.GetItemCategory
{
    public class GetItemCategoryUsecase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetItemCategoryUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ItemCategoryInfoDto> Execute()
        {
            ItemCategory category = await unitOfWork.ItemCategory.GetItemCategory(Id);
            ItemCategoryInfoDto result = mapper.Map<ItemCategory, ItemCategoryInfoDto>(category);
            return result;
        }
    }
}
