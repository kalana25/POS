using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System;

namespace POS.UseCases.General.PurchaseUnits.SavePurchaseUnit
{
    public class SavePurchaseUnitUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PurchaseUnitSaveDto Dto { get; set; }
        public string CreatedBy { get; set; }

        public SavePurchaseUnitUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PurchaseUnit> Execute()
        {
            PurchaseUnit unit = mapper.Map<PurchaseUnitSaveDto, PurchaseUnit>(Dto);
            unit.CreatedBy = this.CreatedBy;
            unit.CreatedOn = DateTime.Now;
            unitOfWork.PurchaseUnits.Add(unit);
            await unitOfWork.Complete();
            return unit;
        }
    }
}
