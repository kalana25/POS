using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Suppliers.GetNextSupplierCode
{
    public class GetNextSupplierCodeUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextSupplierCodeUsecase(IUnitOfWork unitOfwork)
        {
            this.unitOfWork = unitOfwork;
        }

        public async Task<string> Execute()
        {
            int supplierId = await unitOfWork.Suppliers.GetLastSupplierId();
            int nextId = supplierId;
            nextId += 1;
            string result = nextId.ToString().PadLeft(4, '0');
            return $"SU{result}";
        }
    }
}
