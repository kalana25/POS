using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.Suppliers.UpdateSupplier
{
    public class UpdateSupplierUseCase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public SupplierSaveDto Dto { get; set; }

        public UpdateSupplierUseCase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            Supplier supplier = await unitOfWork.Suppliers.Get(this.Id);
            mapper.Map<SupplierSaveDto, Supplier>(Dto, supplier);
            return await unitOfWork.Complete();
        }


    }
}
