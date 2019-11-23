using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Items.SaveItem
{
    public class SaveItemUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ItemSaveDto Dto { get; set; }

        public SaveItemUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Item> Execute()
        {
            Item item = mapper.Map<ItemSaveDto, Item>(Dto);
            unitOfWork.Item.Add(item);
            await unitOfWork.Complete();
            return item;
        }
    }
}
