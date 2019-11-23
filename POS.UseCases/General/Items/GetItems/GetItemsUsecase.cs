﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Items.GetItems
{
    public class GetItemsUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetItemsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ItemInfoDto>> Execute()
        {
            IEnumerable<Item> item = await unitOfWork.Item.GetItems();
            IEnumerable<ItemInfoDto> result = mapper.Map<IEnumerable<Item>, IEnumerable<ItemInfoDto>>(item);
            return result;
        }
    }
}
