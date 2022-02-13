using System.Threading.Tasks;
using POS.Core.Interfaces;
using AutoMapper;
using POS.Models;
using POS.Repositories;
using System;
using POS.UseCases.DTO;

namespace POS.UseCases.General.Orders.GetNextSalesCode
{
    public class GetNextOrderCodeUsecase:UseCase
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNextOrderCodeUsecase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<string> Execute()
        {
            Order order = await unitOfWork.Orders.GetLastOrder();
            DateTime today = DateTime.Today;
            string datePart = $"{today.Day.ToString().PadLeft(2, '0')}{today.Month.ToString().PadLeft(2, '0')}{today.ToString("yy")}";
            if (order != null)
            {
                int nextId = order.Id;
                nextId += 1;
                string result = $"{datePart}{nextId.ToString().PadLeft(4, '0')}";
                return $"OD{result}";
            }
            return $"{datePart}OD0001";
        }
    }
}
