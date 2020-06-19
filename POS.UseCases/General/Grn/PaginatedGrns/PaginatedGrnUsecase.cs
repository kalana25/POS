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

namespace POS.UseCases.General.Grn.PaginatedGrns
{
    public class PaginatedGrnUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedGrnUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<GrnPaginationHeaderInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.Grns.GetPagination(RequestData);
            IEnumerable<GrnPaginationHeaderInfoDto> result = mapper.Map<IEnumerable<GoodReceivedNote>, IEnumerable<GrnPaginationHeaderInfoDto>>(respond.Items);
            return new ResponseData<GrnPaginationHeaderInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
