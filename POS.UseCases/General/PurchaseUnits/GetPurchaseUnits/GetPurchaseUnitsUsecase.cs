using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.PurchaseUnits.GetPurchaseUnits
{
    public class GetPurchaseUnitsUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetPurchaseUnitsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PurchaseUnitInfoDto>> Execute()
        {
            IEnumerable<PurchaseUnit> purchaseUnits = await unitOfWork.PurchaseUnits.GetAll();
            IEnumerable<PurchaseUnitInfoDto> result = mapper.Map<IEnumerable<PurchaseUnit>, IEnumerable<PurchaseUnitInfoDto>>(purchaseUnits);
            return result;
        }
    }
}
