using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.ItemCategories.GetItemCategories
{
    public class GetItemCategoriesUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetItemCategoriesUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ItemCategoryInfoDto>> Execute()
        {
            IEnumerable<ItemCategory> categories = await unitOfWork.ItemCategories.GetItemCategories();
            IEnumerable<ItemCategoryInfoDto> result = mapper.Map<IEnumerable<ItemCategory>, IEnumerable<ItemCategoryInfoDto>>(categories);
            return result;
        }
    }
}
