using AutoMapper;
using POS.Core.Interfaces;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POS.UseCases.General.Suppliers.UpdateSupplierContact
{
    public class UpdateSupplierContactUseCase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public SupplierContactSaveDto Dto { get; set; }

        public UpdateSupplierContactUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            SupplierContact supplierContact = await unitOfWork.SupplierContacts.Get(this.Id);
            mapper.Map<SupplierContactSaveDto, SupplierContact>(Dto, supplierContact);
            return await unitOfWork.Complete();
        }

    }
}
