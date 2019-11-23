using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using POS.Models;
using POS.UseCases.DTO;

namespace POS.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DTOToModel

            CreateMap<SupplierSaveDto, Supplier>();
            CreateMap<ItemCategorySaveDto, ItemCategory>();
            CreateMap<ItemSaveDto, Item>();


            #endregion

            #region ModelToDTO

            //CreateMap<ResourcePlan, ResourcePlanWithProfileInfoDTO>()
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
            //    .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
            //    .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
            //    .ForMember(d => d.ResourceProfiles, m => m.MapFrom(o=>o.PlanProfiles));
            ////.ForMember(d => d.ResourceProfiles, m => m.Ignore());

            CreateMap<Supplier, SupplierInfoDto>();
            CreateMap<ItemCategory, ItemCategoryInfoDto>();
            CreateMap<Item, ItemInfoDto>();

            #endregion
        }
    }
}
