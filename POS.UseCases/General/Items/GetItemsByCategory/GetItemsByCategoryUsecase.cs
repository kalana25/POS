using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
namespace POS.UseCases.General.Items.GetItemsByCategory
{
    public class GetItemsByCategoryUsecase : UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int CategoryId { get; set; }

        public GetItemsByCategoryUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ItemInfoDto>> Execute()
        {
            IEnumerable<Item> item = await unitOfWork.Items.GetItemsByCategoyry(this.CategoryId);
            IEnumerable<ItemInfoDto> result = mapper.Map<IEnumerable<Item>, IEnumerable<ItemInfoDto>>(item);
            return result;
        }
    }
}
