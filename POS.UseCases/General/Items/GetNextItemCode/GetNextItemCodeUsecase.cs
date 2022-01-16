using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Items.GetNextItemCode
{
    public class GetNextItemCodeUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextItemCodeUsecase(IUnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public async Task<string> Execute()
        {
            int itemId = await unitOfWork.Items.GetLastItemId();
            int nextId = itemId;
            nextId += 1;
            string result = nextId.ToString().PadLeft(4, '0');
            return $"IT{result}";
        }
    }
}
