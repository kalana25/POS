
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using POS.Models;
using POS.UseCases.DTO;
using POS.UseCases.DTO.Supplier;

namespace POS.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DTOToModel
            
            CreateMap<SupplierSaveDto, Supplier>();
            CreateMap<SupplierContactSaveDto, SupplierContact>();
            CreateMap<ItemCategorySaveDto, ItemCategory>();
            CreateMap<ItemSaveDto, Item>();

            CreateMap<PurchaseOrderSaveDto, PurchaseOrder>();
            CreateMap<PurchaseOrderSaveDetail, PurchaseOrderDetail>();

            CreateMap<PurchaseOrderUpdateDto, PurchaseOrder>();
            CreateMap<PurchaseOrderUpdateDetail, PurchaseOrderDetail>();

            CreateMap<GrnSaveDto, GoodReceivedNote>();
            CreateMap<GrnSaveDetail, GoodReceivedNoteItem>();

            CreateMap<DiscountSaveDto, Discount>();

            CreateMap<BaseUnitSaveDto, BaseUnit>();
            CreateMap<PurchaseUnitSaveDto, PurchaseUnit>();
            
            #endregion

            #region ModelToDTO

            //CreateMap<ResourcePlan, ResourcePlanWithProfileInfoDTO>()
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
            //    .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
            //    .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
            //    .ForMember(d => d.ResourceProfiles, m => m.MapFrom(o=>o.PlanProfiles));
            ////.ForMember(d => d.ResourceProfiles, m => m.Ignore());
            
            CreateMap<IdentityUser, UserInfoDto>();
            CreateMap<Supplier, SupplierInfoDto>();
            CreateMap<SupplierContact, SupplierContactDto>();
            CreateMap<ItemCategory, ItemCategoryInfoDto>();
            CreateMap<Item, ItemInfoDto>();
            CreateMap<PurchaseOrder, PoHeaderInfoDto>()
                .ForMember(d => d.SupplierName, m => m.MapFrom(o => o.Supplier.Name));

            CreateMap<PurchaseUnit, PurchaseUnitFullInfoWithBaseUnitDto>();
            CreateMap<PurchaseUnit, PurchaseUnitFullInfoDto>();

            CreateMap<BaseUnit, BaseUnitFullInfoDto>();

            CreateMap<Unit, UnitInfoDto>()
                .Include<BaseUnit, BaseUnitInfoDto>()
                .Include<PurchaseUnit, PurchaseUnitInfoDto>();

            CreateMap<PurchaseUnit, PurchaseUnitInfoDto>()
                .ForMember(d => d.BaseUnitName, m => m.MapFrom(o => o.BaseUnit.Name))
                .ForMember(d => d.ItemName, m => m.MapFrom(o => o.Item.Name));
            CreateMap<BaseUnit, BaseUnitInfoDto>();


            CreateMap<Discount, DiscountInfoDto>();
            CreateMap<Discount, DiscountWithItemDto>();

            //This is because PoWithFullInfoDto is inherited by PoHeaderInfoDto
            CreateMap<PoHeaderInfoDto, PoWithFullInfoDto>();
            CreateMap<PurchaseOrderDetail, PoDetailInfoWithItemAndUnitDto>();
            CreateMap<PurchaseOrderDetail, PoDetailInfoWithItemDto>();

            CreateMap<GoodReceivedNote, GrnPaginationHeaderInfoDto>()
                .ForMember(d => d.PurchaseOrderCode, m => m.MapFrom(o => o.PurchaseOrder.Code));
            CreateMap<GoodReceivedNote, GrnHeaderInfoDto>();

            CreateMap<GoodReceivedNote, GrnWithFullInfoDto>();

            CreateMap<Inventory, InventoryHeaderWithFullInfoDto>();
            CreateMap<Inventory, InventoryHeaderInfoWithItemAndUnit>();
            CreateMap<InventoryDetail, InventoryDetailWithUnitAndGrnInfoDto>();
            CreateMap<Inventory, InventoryItemDto>()
                .ForMember(d => d.ItemName, m => m.MapFrom(o => o.Item.Name));


            CreateMap<GoodReceivedNoteItem, GrnItemFullInfoDto>();
            
            #endregion
        }
    }
}
