﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.ItemCategories.GetItemCategoriesByParentAndLevel
{
    public class GetItemCategoriesByParentAndLevel: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Level { get; set; }
        public int Parent { get; set; }

        public GetItemCategoriesByParentAndLevel(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ItemCategoryInfoDto>> Execute()
        {
            IEnumerable<ItemCategory> categories = await unitOfWork.ItemCategories.GetItemCategoriesByParentAndLevel(Parent,Level);
            IEnumerable<ItemCategoryInfoDto> result = mapper.Map<IEnumerable<ItemCategory>, IEnumerable<ItemCategoryInfoDto>>(categories);
            return result;
        }
    }
}
