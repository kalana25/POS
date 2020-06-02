using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System;

namespace POS.UseCases.General.BaseUnits.SaveBaseUnit
{
    public class SaveBaseUnitUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public BaseUnitSaveDto Dto { get; set; }
        public string CreatedBy { get; set; }

        public SaveBaseUnitUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<BaseUnit> Execute()
        {
            BaseUnit unit = mapper.Map<BaseUnitSaveDto, BaseUnit>(Dto);
            unit.CreatedBy = this.CreatedBy;
            unit.CreatedOn = DateTime.Now;
            unitOfWork.BaseUnits.Add(unit);
            await unitOfWork.Complete();
            return unit;
        }
    }
}
