using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;

namespace POS.UseCases.General.PurchaseOrders.SavePurchaseOrder
{
    public class SavePurchaseOrderUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PurchaseOrderSaveDto Dto { get; set; }

        public SavePurchaseOrderUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PoHeaderInfoDto> Execute()
        {
            PurchaseOrder header = mapper.Map<PurchaseOrderSaveDto, PurchaseOrder>(Dto);
            //PurchaseOrderD
            //PurchaseOrder purchaseOrder = await unitOfWork.PurchaseOrders.Get(Id);
            //PoHeaderInfoDto result = mapper.Map<PurchaseOrder, PoHeaderInfoDto>(purchaseOrder);
            //return result;
            return null;
        }
    }
}
