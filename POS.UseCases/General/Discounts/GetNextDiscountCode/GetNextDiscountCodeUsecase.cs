using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Discounts.GetNextDiscountCode
{
    public class GetNextDiscountCodeUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextDiscountCodeUsecase(IUnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public async Task<string> Execute()
        {
            int discountId = await unitOfWork.Discounts.GetLastDiscountId();
            int nextId = discountId;
            nextId += 1;
            string result = nextId.ToString().PadLeft(4, '0');
            return $"DC{result}";
        }
    }
}
