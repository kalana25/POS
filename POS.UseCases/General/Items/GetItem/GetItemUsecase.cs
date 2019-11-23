using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Items.GetItem
{
    public class GetItemUsecase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetItemUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ItemInfoDto> Execute()
        {
            Item item = await unitOfWork.Item.GetItem(Id);
            ItemInfoDto result = mapper.Map<Item, ItemInfoDto>(item);
            return result;
        }
    }
}
