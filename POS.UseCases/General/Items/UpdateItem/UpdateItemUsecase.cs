using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.Items.UpdateItem
{
    public class UpdateItemUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public ItemSaveDto Dto { get; set; }

        public UpdateItemUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            Item item = await unitOfWork.Item.Get(Id);
            mapper.Map<ItemSaveDto, Item>(Dto, item);
            return await unitOfWork.Complete();
        }
    }
}
