using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Inventories.GetInventoryByItem
{
    public class GetInventoryByItemUsecase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int InventoryId { get; set; }

        public GetInventoryByItemUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<InventoryHeaderWithFullInfoDto> Execute()
        {
            var inventory = await unitOfWork.Inventories.GetInventoryWithDetailsByItem(InventoryId);
            InventoryHeaderWithFullInfoDto header = mapper.Map<Inventory, InventoryHeaderWithFullInfoDto>(inventory);
            return header;
        }


    }
}
