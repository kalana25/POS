using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            CreateMap<GoodReceivedNoteSaveDto, GoodReceivedNote>();

            CreateMap<DiscountSaveDto, Discount>();

            CreateMap<BaseUnitSaveDto, BaseUnit>();
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

            CreateMap<PurchaseUnit, PurchaseUnitInfoDto>()
                .ForMember(d => d.BaseUnitName, m => m.MapFrom(o => o.BaseUnit.Name));

            CreateMap<Discount, DiscountInfoDto>();
            CreateMap<Discount, DiscountWithItemDto>();
            CreateMap<BaseUnit, BaseUnitInfoDto>();
            CreateMap<BaseUnit, BaseUnitFullInfoDto>();

            //This is because PoWithFullInfoDto is inherited by PoHeaderInfoDto
            CreateMap<PoHeaderInfoDto, PoWithFullInfoDto>();
            CreateMap<PurchaseOrderDetail, PoDetailInfoWithItemDto>();
            CreateMap<GoodReceivedNote, GrnHeaderInfoDto>();

            #endregion
        }
    }
}
