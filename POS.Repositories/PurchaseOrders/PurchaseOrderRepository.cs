using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Core.General;
using POS.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace POS.Repositories.PurchaseOrders
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DataBaseContext context) : base(context)
        {

        }

        public override async Task<ResponseData<PurchaseOrder>> GetPagination(RequestData requestData)
        {
            int count = await DatabaseContext.PurchaseOrders.CountAsync();

            IEnumerable<PurchaseOrder> items = await DatabaseContext.PurchaseOrders
                .Include(p=>p.Supplier)
                .Skip((requestData.Page - 1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<PurchaseOrder>(requestData.Page, requestData.PageSize, count, items);
        }

        public async Task<PurchaseOrder> GetPurchaseOrderWithDetails(int id)
        {
            return await DatabaseContext.PurchaseOrders.Include(p => p.Items).FirstOrDefaultAsync(x => x.Id == id);
        }


        //Will include grn and more in furture
        public async Task<PurchaseOrder> GetPurchaseOrderWithFullInfo(int id)
        {
            return await DatabaseContext.PurchaseOrders
                .Include(p=>p.Supplier)
                .Include(p => p.Items)
                .ThenInclude(i=>i.Item)
                .Include(p=>p.Items)
                .ThenInclude(i=>i.Unit)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
