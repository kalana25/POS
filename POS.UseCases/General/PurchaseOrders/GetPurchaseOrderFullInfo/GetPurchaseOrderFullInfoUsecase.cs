﻿using System.Threading.Tasks;
using POS.Core.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using POS.UseCases.DTO;
using System.Collections;
using POS.UseCases.DTO.Supplier;

namespace POS.UseCases.General.PurchaseOrders.GetPurchaseOrderFullInfo
{
    public class GetPurchaseOrderFullInfoUsecase:UseCase
    {
        public int Id { get; set; }

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public GetPurchaseOrderFullInfoUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PoWithFullInfoDto> Execute()
        {
            PurchaseOrder purchaseOrder = await unitOfWork.PurchaseOrders.GetPurchaseOrderWithFullInfo(Id);
            PoHeaderInfoDto header = mapper.Map<PurchaseOrder, PoHeaderInfoDto>(purchaseOrder);
            PoWithFullInfoDto result = mapper.Map<PoHeaderInfoDto, PoWithFullInfoDto>(header);
            result.Supplier = mapper.Map<Supplier, SupplierInfoDto>(purchaseOrder.Supplier);
            result.Items= mapper.Map<IEnumerable<PurchaseOrderDetail>,IEnumerable<PoDetailInfoWithItemAndUnitDto>>(purchaseOrder.Items);
            return result;
        }
    }
}
