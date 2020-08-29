using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.Core.General;
using POS.Models;
using POS.Core.Interfaces;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Inventories.PaginatedInventories
{
    public class PaginatedInventoriesUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedInventoriesUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<InventoryHeaderInfoWithItemAndUnit>> Execute()
        {
            var respond = await this.unitOfWork.Inventories.GetPagination(RequestData);
            IEnumerable<InventoryHeaderInfoWithItemAndUnit> result = mapper.Map<IEnumerable<Inventory>, IEnumerable<InventoryHeaderInfoWithItemAndUnit>>(respond.Items);
            return new ResponseData<InventoryHeaderInfoWithItemAndUnit>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
