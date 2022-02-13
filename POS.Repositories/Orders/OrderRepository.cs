using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Core.General;
using POS.Models;
using POS.Models.Enums;

namespace POS.Repositories.Orders
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        public OrderRepository(DataBaseContext context):base(context)
        {

        }

        public async Task<Order> GetLastOrder()
        {
            return await DatabaseContext.Orders.OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
