using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.UseCases.General.Inventories.GetInventoryByCategory
{
    public class GetInventoryByCategoryUsecase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int CategoryId { get; set; }

        public GetInventoryByCategoryUsecase(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<InventoryItemDto>> Execute()
        {
            var inventoryItems = await this.unitOfWork.Inventories.GetInventoryByCategoryId(this.CategoryId);
            IEnumerable<InventoryItemDto> result = mapper.Map<IEnumerable<Inventory>,IEnumerable<InventoryItemDto>>(inventoryItems);
            return result;
        }
    }
}
