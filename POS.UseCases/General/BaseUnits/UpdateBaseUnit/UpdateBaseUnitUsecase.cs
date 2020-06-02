using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO;
using POS.Models;
using POS.Core.Interfaces;
using System;

namespace POS.UseCases.General.BaseUnits.UpdateBaseUnit
{
    public class UpdateBaseUnitUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public BaseUnitSaveDto Dto { get; set; }
        public string UpdatedBy { get; set; }

        public UpdateBaseUnitUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            BaseUnit unit = await unitOfWork.BaseUnits.Get(Id);
            unit.UpdatedBy = this.UpdatedBy;
            unit.UpdatedOn = DateTime.Now;
            mapper.Map<BaseUnitSaveDto, BaseUnit>(Dto, unit);
            return await unitOfWork.Complete();
        }
    }
}
