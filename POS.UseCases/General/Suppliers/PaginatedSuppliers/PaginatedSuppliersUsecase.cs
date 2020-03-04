using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using POS.Core.General;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;

namespace POS.UseCases.General.Suppliers.PaginatedSuppliers
{
    public class PaginatedSuppliersUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedSuppliersUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<SupplierInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.Suppliers.GetPagination(RequestData);
            IEnumerable<SupplierInfoDto> result = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierInfoDto>>(respond.Items);
            return new ResponseData<SupplierInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
