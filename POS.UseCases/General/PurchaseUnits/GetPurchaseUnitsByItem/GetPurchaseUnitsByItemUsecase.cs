using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using POS.Models;
using POS.Core.Interfaces;
using POS.UseCases.DTO;


namespace POS.UseCases.General.PurchaseUnits.GetPurchaseUnitsByItem
{
    public class GetPurchaseUnitsByItemUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public int ItemId { get; set; }

        public GetPurchaseUnitsByItemUsecase(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseUnitFullInfoWithBaseUnitDto>> Execute()
        {
            var purchaseUnits = await unitOfWork.PurchaseUnits.GetByItem(ItemId);
            IEnumerable<PurchaseUnitFullInfoWithBaseUnitDto> list = mapper.Map<IEnumerable<PurchaseUnit>, IEnumerable<PurchaseUnitFullInfoWithBaseUnitDto>>(purchaseUnits);
            return list;
        }

    }
}
