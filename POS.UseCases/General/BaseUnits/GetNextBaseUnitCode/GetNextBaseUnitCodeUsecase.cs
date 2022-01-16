using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
namespace POS.UseCases.General.BaseUnits.GetNextBaseUnitCode
{
    public class GetNextBaseUnitCodeUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextBaseUnitCodeUsecase(IUnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public async Task<string> Execute()
        {
            int baseUnitId = await unitOfWork.BaseUnits.GetLastBaseUnitId();
            int nextId = baseUnitId;
            nextId += 1;
            string result = nextId.ToString().PadLeft(4, '0');
            return $"BU{result}";
        }
    }
}
