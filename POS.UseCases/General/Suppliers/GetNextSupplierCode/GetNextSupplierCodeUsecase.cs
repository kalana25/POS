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
            Supplier supplier = await unitOfWork.Suppliers.GetLastSupplier();
            if (supplier != null)
            {
                int nextId = supplier.Id;
                nextId += 1;
                string result = nextId.ToString().PadLeft(4, '0');
                return $"SU{result}";
            }
            return "SU0001";
        }
    }
}
