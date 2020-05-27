using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using POS.Models;
using POS.Core.Interfaces;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Discounts.SaveDiscount
{
    public class SaveDiscountUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DiscountSaveDto Dto { get; set; }

        public SaveDiscountUsecase(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Discount> Execute()
        {
            Discount discount = mapper.Map<DiscountSaveDto, Discount>(Dto);
            unitOfWork.Discounts.Add(discount);
            await unitOfWork.Complete();
            return discount;
        }

    }
}
