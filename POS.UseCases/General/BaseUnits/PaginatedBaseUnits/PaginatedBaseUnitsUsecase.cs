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

namespace POS.UseCases.General.BaseUnits.PaginatedBaseUnits
{
    public class PaginatedBaseUnitsUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedBaseUnitsUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<BaseUnitInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.BaseUnits.GetPagination(RequestData);
            IEnumerable<BaseUnitInfoDto> result = mapper.Map<IEnumerable<BaseUnit>, IEnumerable<BaseUnitInfoDto>>(respond.Items);
            return new ResponseData<BaseUnitInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
