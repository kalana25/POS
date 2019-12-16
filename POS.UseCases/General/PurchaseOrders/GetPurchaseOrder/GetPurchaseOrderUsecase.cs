using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;


namespace POS.UseCases.General.PurchaseOrders.GetPurchaseOrder
{
    public class GetPurchaseOrderUsecase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public GetPurchaseOrderUsecase(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PoHeaderInfoDto> Execute()
        {
            PurchaseOrder purchaseOrder = await unitOfWork.PurchaseOrders.Get(Id);
            PoHeaderInfoDto result = mapper.Map<PurchaseOrder, PoHeaderInfoDto>(purchaseOrder);
            return result;
        }
    }
}
