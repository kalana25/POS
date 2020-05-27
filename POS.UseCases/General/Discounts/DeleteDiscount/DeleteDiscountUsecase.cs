using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using POS.Repositories;
using POS.UseCases.DTO.Supplier;
using POS.Models;
using POS.Core.Interfaces;

namespace POS.UseCases.General.Discounts.DeleteDiscount
{
    public class DeleteDiscountUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;
        public int Id { get; set; }

        public DeleteDiscountUsecase(IUnitOfWork unitOfWrk)
        {
            unitOfWork = unitOfWrk;
        }

        public async Task<int> Execute()
        {
            Discount discount = await unitOfWork.Discounts.Get(Id);
            unitOfWork.Discounts.Remove(discount);
            return await unitOfWork.Complete();
        }

    }
}
