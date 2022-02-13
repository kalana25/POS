using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using System.Linq;
using POS.Core.DI;

namespace POS.Repositories.Orders
{
    [AutoDIService]
    public interface IOrderRepository:IRepository<Order>
    {
        Task<Order> GetLastOrder();

    }
}
