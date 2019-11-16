using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AgendaWeb.Models;

namespace AgendaWeb.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region DTOToModel

            //CreateMap<StyleDTO, Style>()
            //    .ForMember(d => d.CustomStyle, m => m.MapFrom(o => o.CustomStyle))
            //    .ForMember(d => d.BackgroundColor, m => m.MapFrom(o => o.BackgroundColor))
            //    .ForMember(d => d.FontColor, m => m.MapFrom(o => o.FontColor))
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
            //    .ForMember(d => d.Name, m => m.MapFrom(o => o.Name));

            //CreateMap<ResourceProfileDTO, ResourceProfile>();

            //CreateMap<ResourcePlanSaveDTO, ResourcePlan>();

            //CreateMap<ResourcePlanUpdateDTO, ResourcePlan>()
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
            //    .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
            //    .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
            //    .ForMember(d => d.PlanProfiles, m => m.Ignore());

            //CreateMap<PatientSaveDTO, Patient>()
            //    .ForMember(d => d.FristName, m => m.MapFrom(o => o.FristName))
            //    .ForMember(d => d.LastName, m => m.MapFrom(o => o.LastName))
            //    .ForMember(d => d.OtherNames, m => m.MapFrom(o => o.OtherNames))
            //    .ForMember(d => d.NIC, m => m.MapFrom(o => o.NIC))
            //    .ForMember(d => d.Address, m => m.MapFrom(o => o.Address))
            //    .ForMember(d => d.Communication, m => m.MapFrom(o => o.Communication));

            //CreateMap<AddressSaveDTO, Address>();
            //CreateMap<AddressInfoDTO, Address>();

            //CreateMap<CommunicationSaveDTO, Communication>();
            //CreateMap<CommunicationInfoDTO, Communication>();

            //CreateMap<PatientUpdateDTO, Patient>();

            //CreateMap<CollaboratorSaveDTO, Collaborator>();
            //CreateMap<CollaboratorUpdateDTO, Collaborator>();

            //CreateMap<ResourceSaveDTO, Resource>();
            //CreateMap<ResourceUpdateDTO, Resource>();

            //CreateMap<VisitReasonSaveDTo, VisitReason>();
            //CreateMap<VisitReasonUpdateDto, VisitReason>();


            #endregion

            #region ModelToDTO

            //CreateMap<ResourcePlanProfile, ResourceProfileInfoDTO>()
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.ResourceProfile.Id))
            //    .ForMember(d => d.Name, m => m.MapFrom(o => o.ResourceProfile.Name))
            //    .ForMember(d => d.Description, m => m.MapFrom(o => o.ResourceProfile.Description));

            //CreateMap<ResourcePlan, ResourcePlanWithProfileInfoDTO>()
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
            //    .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
            //    .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
            //    .ForMember(d => d.ResourceProfiles, m => m.MapFrom(o=>o.PlanProfiles));
            ////.ForMember(d => d.ResourceProfiles, m => m.Ignore());

            //CreateMap<Patient, PatientWithFullInfoDTO>()
            //    .ForMember(d => d.Id, m => m.MapFrom(o => o.Id))
            //    .ForMember(d => d.FristName, m => m.MapFrom(o => o.FristName))
            //    .ForMember(d => d.LastName, m => m.MapFrom(o => o.LastName))
            //    .ForMember(d => d.OtherNames, m => m.MapFrom(o => o.OtherNames))
            //    .ForMember(d => d.NIC, m => m.MapFrom(o => o.NIC))
            //    .ForMember(d => d.Address, m => m.MapFrom(o => o.Address))
            //    .ForMember(d => d.Communication, m => m.MapFrom(o => o.Communication));

            //CreateMap<Address, AddressInfoDTO>();

            //CreateMap<Communication, CommunicationInfoDTO>();

            //CreateMap<Collaborator, CollaboratorWithFullInfoDTO>();

            //CreateMap<Resource, ResourceWithFullInfoDTO>();

            //CreateMap<VisitReason, VisitReasonWithFullInfoDto>();

            #endregion
        }
    }
}
