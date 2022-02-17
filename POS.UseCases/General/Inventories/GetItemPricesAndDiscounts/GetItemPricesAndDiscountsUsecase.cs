using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.Models.StoredProcedureModels;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Inventories.GetItemPricesAndDiscounts
{
    public class GetItemPricesAndDiscountsUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public int ItemId { get; set; }
        public DateTime Date { get; set; }

        public GetItemPricesAndDiscountsUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ItemPricesWithDiscount> Execute()
        {
            var inventoryHeaders = await this.unitOfWork.Inventories.GetInventoryWithDetailsByItem(ItemId);
            var validDiscounts = await this.unitOfWork.Discounts.GetValidDiscountByItemAndDate(ItemId, Date);
            IEnumerable<DiscountInfoDto> discountDtoList = mapper.Map<IEnumerable<Discount>, IEnumerable<DiscountInfoDto>>(validDiscounts);
            IEnumerable<InventoryHeaderBase> inventoryHeaderDtoList = mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryHeaderBase>>(inventoryHeaders);

            return new ItemPricesWithDiscount { AvailableDicounts = discountDtoList, Inventories = inventoryHeaderDtoList };
        }
    }
}
