using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.Suppliers.SaveSupplier
{
    public class SaveSupplierUsecase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SupplierSaveDto Dto { get; set; }

        public SaveSupplierUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Supplier> Execute()
        {
            Supplier supplier = mapper.Map<SupplierSaveDto, Supplier>(Dto);
            unitOfWork.Suppliers.Add(supplier);
            await unitOfWork.Complete();
            return supplier;
        }
    }
}
