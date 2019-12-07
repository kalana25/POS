using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using POS.Core.General;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Suppliers.PaginatedSuppliers
{
    public class PaginatedSuppliersUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PaginatedSuppliersUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<SupplierInfoDto>> Execute(RequestData reqData)
        {
            var respond = await this.unitOfWork.Suppliers.GetPagination(reqData);
            IEnumerable<SupplierInfoDto> result = mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierInfoDto>>(respond.Items);
            return new ResponseData<SupplierInfoDto>(reqData.Page, reqData.PageSize, respond.TotalCount, result);
        }
    }
}
