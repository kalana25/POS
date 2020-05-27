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

namespace POS.UseCases.General.Discounts.UpdateDiscount
{
    public class UpdateDiscountUsecase:UseCase
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public int Id { get; set; }
        public DiscountSaveDto Dto { get; set; }

        public UpdateDiscountUsecase(
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Execute()
        {
            Discount discount = await unitOfWork.Discounts.Get(this.Id);
            mapper.Map<DiscountSaveDto, Discount>(Dto, discount);
            return await unitOfWork.Complete();
        }
    }
}
