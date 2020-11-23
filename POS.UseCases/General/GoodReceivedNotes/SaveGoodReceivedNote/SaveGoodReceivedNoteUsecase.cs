using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System;
using POS.Models.Enums;
using System.Linq;

namespace POS.UseCases.General.GoodReceivedNotes.SaveGoodReceivedNote
{
    public class SaveGoodReceivedNoteUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GrnSaveDto Dto { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }

        public SaveGoodReceivedNoteUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<GrnHeaderInfoDto> Execute()
        {
            #region Insert GRN

            GoodReceivedNote grnHeader = mapper.Map<GrnSaveDto, GoodReceivedNote>(Dto);
            grnHeader.CreatedOn = DateTime.Now;
            grnHeader.CreatedBy = this.CreatedBy;
            grnHeader.CreatedByName = CreatedByName;
            grnHeader.Time = DateTime.Now;
            List<GoodReceivedNoteItem> details = mapper.Map<List<GrnSaveDetail>, List<GoodReceivedNoteItem>>(Dto.Items);
            grnHeader.Items = details;
            unitOfWork.GoodReceivedNotes.Add(grnHeader);

            #endregion

            #region Update Inventory

            foreach(var detail in details)
            {
                Inventory inventory = await unitOfWork.Inventories.GetInventoryWithDetailsByItem(detail.ItemId);
                if (inventory == null)  // If No inventory
                {
                    //new inventory
                    var item = await unitOfWork.Items.Get(detail.ItemId);
                    inventory = new Inventory
                    {
                        ItemId = detail.ItemId,
                        ReOrderLevel = item.ReOrderLevel,
                        CreatedBy = this.CreatedBy,
                        CreatedOn = DateTime.Now,
                        CreatedByName = this.CreatedByName
                    };
                    PurchaseUnit purchaseUnit = null;
                    if (detail.IsBaseUnit)
                    {
                        inventory.BaseUnitId = detail.UnitId;
                        inventory.Quantity = detail.Quantity;
                    } 
                    else
                    {
                        purchaseUnit =await unitOfWork.PurchaseUnits.Get(detail.UnitId);
                        inventory.BaseUnitId = purchaseUnit.BaseUnitId;
                        inventory.Quantity = detail.Quantity * purchaseUnit.Quantity;
                    }

                    //new Inventory details
                    inventory.Details = new List<InventoryDetail>();
                    inventory.Details.Add(new InventoryDetail
                    {
                        ExpireDate = detail.ExpireDate,
                        Quantity = detail.Quantity,
                        SellingPrice = detail.SellingPrice,
                        PurchasingPrice = detail.PurchasingPrice,
                        StockInDate = DateTime.Now,
                        IsBaseUnit = detail.IsBaseUnit,
                        UnitId = detail.UnitId,
                        GoodReceivedNote = grnHeader,
                        OpenBalanceQuantity = detail.Quantity,
                        SellingPricePerBaseUnit = (detail.IsBaseUnit)?detail.SellingPrice:detail.SellingPrice/purchaseUnit.Quantity,
                        PurchasingPricePerBaseUnit = (detail.IsBaseUnit)?detail.PurchasingPrice:detail.PurchasingPrice/purchaseUnit.Quantity
                    });
                    unitOfWork.Inventories.Add(inventory);
                }
                else  //If there is an inventory
                {
                    PurchaseUnit purchaseUnit = null;
                    // update inventory
                    if (detail.IsBaseUnit)
                    {
                        inventory.Quantity += detail.Quantity;
                    } 
                    else
                    {
                        purchaseUnit = await unitOfWork.PurchaseUnits.Get(detail.UnitId);
                        inventory.Quantity = detail.Quantity * purchaseUnit.Quantity;
                    }
                    inventory.UpdatedBy = CreatedBy;
                    inventory.UpdatedByName = CreatedByName;
                    inventory.UpdatedOn = DateTime.Now;
                    unitOfWork.InventoryDetails.Add(
                    new InventoryDetail
                    {
                        InventoryId = inventory.Id,
                        ExpireDate = detail.ExpireDate,
                        Quantity = detail.Quantity,
                        SellingPrice = detail.SellingPrice,
                        PurchasingPrice = detail.PurchasingPrice,
                        StockInDate = DateTime.Now,
                        IsBaseUnit = detail.IsBaseUnit,
                        UnitId = detail.UnitId,
                        GoodReceivedNote = grnHeader,
                        OpenBalanceQuantity = detail.Quantity,
                        SellingPricePerBaseUnit = (detail.IsBaseUnit) ? detail.SellingPrice:detail.SellingPrice/purchaseUnit.Quantity,
                        PurchasingPricePerBaseUnit = (detail.IsBaseUnit) ? detail.PurchasingPrice : detail.PurchasingPrice / purchaseUnit.Quantity,
                    });
                }

            }

            #endregion

            #region Update PurchaseOrder

            var po = await unitOfWork.PurchaseOrders.Get(Dto.PurchaseOrderId);
            po.Status = Dto.PurchaseOrderStatus;

            #endregion

            await unitOfWork.Complete();
            var headerDto = this.mapper.Map<GoodReceivedNote, GrnHeaderInfoDto>(grnHeader);
            return headerDto;
        }
    }
}
