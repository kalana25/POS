using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;

namespace POS.UseCases.General.Suppliers.GetSuppliers
{
    public class GetSuppliersUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetSuppliersUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SupplierInfoDto>> Execute()
        {
            IEnumerable<Supplier> itmes = await unitOfWork.Suppliers.GetSuppliersWithContacts();
            IEnumerable<SupplierInfoDto> result = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierInfoDto>>(itmes);
            return result;
        }
    }
}
