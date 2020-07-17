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
                        Quantity = detail.Quantity,
                        ReOrderLevel = item.ReOrderLevel,
                        CreatedBy = this.CreatedBy,
                        CreatedOn = DateTime.Now,
                        CreatedByName = this.CreatedByName
                    };
                    if(detail.IsBaseUnit)
                    {
                        inventory.BaseUnitId = detail.UnitId;
                    } 
                    else
                    {
                        var purchaseUnit =await unitOfWork.PurchaseUnits.Get(detail.UnitId);
                        inventory.BaseUnitId = purchaseUnit.BaseUnitId;
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
                        GoodReceivedNote = grnHeader
                    });
                    unitOfWork.Inventories.Add(inventory);
                }
                else  //If there is an inventory
                {
                    // update inventory
                    inventory.Quantity += detail.Quantity;
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
                        GoodReceivedNote = grnHeader
                    });
                }

            }

            #endregion


            await unitOfWork.Complete();
            var headerDto = this.mapper.Map<GoodReceivedNote, GrnHeaderInfoDto>(grnHeader);
            return headerDto;
        }
    }
}
