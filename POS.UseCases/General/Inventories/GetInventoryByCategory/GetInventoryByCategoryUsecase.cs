using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Models.StoredProcedureModels;
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

        public async Task<IEnumerable<UniqueStockItemByCategory>> Execute()
        {
            var inventoryItems = await this.unitOfWork.Inventories.GetInventoryByCategoryId(this.CategoryId);
            return inventoryItems;
        }
    }
}
