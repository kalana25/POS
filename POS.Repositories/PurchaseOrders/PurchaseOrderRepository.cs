using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.PurchaseOrders
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DataBaseContext context) : base(context)
        {

        }

        //public async Task<PurchaseOrder> GetPurchaseOrder(int id)
        //{
        //    return await DatabaseContext.PurchaseOrders.FindAsync(id);
        //}

        //public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders()
        //{
        //    return await DatabaseContext.PurchaseOrders.ToListAsync();
        //}

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
