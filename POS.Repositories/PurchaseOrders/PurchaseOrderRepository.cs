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

        public async Task<PurchaseOrder> GetPurchaseOrderWithDetails(int id)
        {
            return await DatabaseContext.PurchaseOrders.Include(p => p.Items).FirstOrDefaultAsync(x => x.Id == id);
        }


        //Will include grn and more in furture
        public async Task<PurchaseOrder> GetPurchaseOrderWithFullInfo(int id)
        {
            return await DatabaseContext.PurchaseOrders.Include(p => p.Items).ThenInclude(i=>i.Item).FirstOrDefaultAsync(x => x.Id == id);
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
