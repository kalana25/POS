using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using POS.Models;
using POS.Core.Interfaces;
using POS.UseCases.DTO;


namespace POS.UseCases.General.PurchaseUnits.GetPurchaseUnit
{
    public class GetPurchaseUnitUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public int Id { get; set; }

        public GetPurchaseUnitUsecase(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PurchaseUnitFullInfoDto> Execute()
        {
            var purchaseUnit = await unitOfWork.PurchaseUnits.Get(Id);
            PurchaseUnitFullInfoDto result = mapper.Map<PurchaseUnit, PurchaseUnitFullInfoDto>(purchaseUnit);
            return result;
        }
    }
}
