﻿using System.Threading.Tasks;
using POS.Repositories;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.Suppliers.DeleteSupplier
{
    public class DeleteSupplierUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }

        public DeleteSupplierUsecase(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<int>Execute()
        {
            Supplier supplier = await unitOfWork.Suppliers.Get(Id);
            unitOfWork.Suppliers.Remove(supplier);
            return await unitOfWork.Complete();
        }

    }
}
