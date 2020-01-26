using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
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
            List<PurchaseOrderDetail> details = mapper.Map<List<PurchaseOrderSaveDetail>, List<PurchaseOrderDetail>>(Dto.Items);
            header.Items = details;
            unitOfWork.PurchaseOrders.Add(header);
            await unitOfWork.Complete();
            var headerDto =  this.mapper.Map<PurchaseOrder, PoHeaderInfoDto>(header);
            return headerDto;
        }
    }
}
