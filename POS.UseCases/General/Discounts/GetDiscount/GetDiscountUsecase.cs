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

namespace POS.UseCases.General.Discounts.GetDiscount
{
    public class GetDiscountUsecase: UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public int Id { get; set; }

        public GetDiscountUsecase(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<DiscountWithItemDto> Execute()
        {
            var discount = await unitOfWork.Discounts.Get(Id);
            DiscountWithItemDto result = mapper.Map<Discount, DiscountWithItemDto>(discount);
            return result;
        }
    }
}
