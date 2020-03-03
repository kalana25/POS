using AutoMapper;
using POS.Core.Interfaces;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POS.UseCases.General.Suppliers.SaveSupplierContact
{
    public class SaveSupplierContactUseCase : UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SupplierContactSaveDto Dto { get; set; }

        public SaveSupplierContactUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SupplierContact> Execute()
        {
            SupplierContact supplierContact = mapper.Map<SupplierContactSaveDto, SupplierContact>(Dto);
            unitOfWork.SupplierContacts.Add(supplierContact);
            await unitOfWork.Complete();
            return supplierContact;
        }

        public void GenerateContactBySuppler(Supplier supplier)
        {
            SupplierContact supplierContact = new SupplierContact() {
                SupplierId= supplier.Id,
                Active = true,
                Position = "Default",
                FirstName = supplier.Name,
                ContactNumber = supplier.ContactNo,
                Telephone = supplier.Telephone,
                Email = supplier.Email,
                Mobile = "",
                LastName = ""
            };
            unitOfWork.SupplierContacts.Add(supplierContact);
            unitOfWork.Complete();
        }
    }
}
