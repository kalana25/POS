using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.PurchaseUnits.GetNextPurchaseUnitCode
{
    public class GetNextPurchaseUnitCodeUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextPurchaseUnitCodeUsecase(IUnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public async Task<string> Execute()
        {
            int purchaseUnitId = await unitOfWork.PurchaseUnits.GetLastPurchaseUnitId();
            int nextId = purchaseUnitId;
            nextId += 1;
            string result = nextId.ToString().PadLeft(4, '0');
            return $"PU{result}";
        }
    }
}
