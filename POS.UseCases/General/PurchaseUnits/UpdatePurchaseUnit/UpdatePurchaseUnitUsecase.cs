using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO;
using POS.Models;
using POS.Core.Interfaces;
using System;


namespace POS.UseCases.General.PurchaseUnits.UpdatePurchaseUnit
{
    public class UpdatePurchaseUnitUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public PurchaseUnitSaveDto Dto { get; set; }
        public string UpdatedBy { get; set; }

        public UpdatePurchaseUnitUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            PurchaseUnit unit = await unitOfWork.PurchaseUnits.Get(Id);
            unit.UpdatedBy = this.UpdatedBy;
            unit.UpdatedOn = DateTime.Now;
            mapper.Map<PurchaseUnitSaveDto, PurchaseUnit>(Dto, unit);
            return await unitOfWork.Complete();
        }
    }
}
