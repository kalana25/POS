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

namespace POS.UseCases.General.Discounts.GetDiscounts
{
    public class GetDiscountsUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetDiscountsUsecase(
            IUnitOfWork unitOw,
            IMapper maper)
        {
            unitOfWork = unitOw;
            mapper = maper;
        }

        public async Task<IEnumerable<DiscountInfoDto>> Execute()
        {
            var discounts =await unitOfWork.Discounts.GetAll();
            IEnumerable<DiscountInfoDto> result = mapper.Map<IEnumerable<Discount>, IEnumerable<DiscountInfoDto>>(discounts);
            return result;
        }
    }
}
