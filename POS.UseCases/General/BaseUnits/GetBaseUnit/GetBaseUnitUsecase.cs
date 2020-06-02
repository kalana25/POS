using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using POS.Models;
using POS.Core.Interfaces;
using POS.UseCases.DTO;

namespace POS.UseCases.General.BaseUnits.GetBaseUnit
{
    public class GetBaseUnitUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public int Id { get; set; }

        public GetBaseUnitUsecase(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<BaseUnitFullInfoDto> Execute()
        {
            var baseUnit = await unitOfWork.BaseUnits.Get(Id);
            BaseUnitFullInfoDto result = mapper.Map<BaseUnit, BaseUnitFullInfoDto>(baseUnit);
            return result;
        }
    }
}
