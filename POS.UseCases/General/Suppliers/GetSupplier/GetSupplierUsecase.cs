using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;


namespace POS.UseCases.General.Suppliers.GetSupplier
{
    public class GetSupplierUsecase: UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetSupplierUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<SupplierInfoDto> Execute()
        {
            Supplier supplier = await unitOfWork.Suppliers.Get(Id);
            SupplierInfoDto result = mapper.Map<Supplier, SupplierInfoDto>(supplier);
            return result;
        }
    }
}
