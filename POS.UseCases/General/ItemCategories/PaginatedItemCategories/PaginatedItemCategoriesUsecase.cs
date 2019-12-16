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

namespace POS.UseCases.General.ItemCategories.PaginatedItemCategories
{
    public class PaginatedItemCategoriesUsecase: UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public RequestData RequestData { get; set; }

        public PaginatedItemCategoriesUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ResponseData<ItemCategoryInfoDto>> Execute()
        {
            var respond = await this.unitOfWork.ItemCategories.GetPagination(RequestData);
            IEnumerable<ItemCategoryInfoDto> result = mapper.Map<IEnumerable<ItemCategory>, IEnumerable<ItemCategoryInfoDto>>(respond.Items);
            return new ResponseData<ItemCategoryInfoDto>(RequestData.Page, RequestData.PageSize, respond.TotalCount, result);
        }
    }
}
