using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;


namespace POS.Repositories.Discounts
{
    [AutoDIService]
    public interface IDiscountRepository:IRepository<Discount>
    {
        Task<Discount> GetDiscountWithItem(int id);
    }
}
