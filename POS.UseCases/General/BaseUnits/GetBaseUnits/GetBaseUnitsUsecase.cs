using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.BaseUnits.GetBaseUnits
{
    public class GetBaseUnitsUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetBaseUnitsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BaseUnitInfoDto>> Execute()
        {
            IEnumerable<BaseUnit> baseUnits = await unitOfWork.BaseUnits.GetAll();
            IEnumerable<BaseUnitInfoDto> result = mapper.Map<IEnumerable<BaseUnit>, IEnumerable<BaseUnitInfoDto>>(baseUnits);
            return result;
        }
    }
}
