using POS.Core.Interfaces;
using POS.Models;
using POS.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POS.UseCases.General.Suppliers.DeleteSupplierContact
{
    public class DeleteSupplierContactUseCase : UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeleteSupplierContactUseCase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            SupplierContact supplierContact = await unitOfWork.SupplierContacts.Get(Id);
            unitOfWork.SupplierContacts.Remove(supplierContact);
            return await unitOfWork.Complete();
        }
    }
}
