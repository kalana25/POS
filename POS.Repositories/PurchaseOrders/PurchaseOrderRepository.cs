using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Core.General;
using POS.Models;
using POS.Models.Enums;
using Microsoft.EntityFrameworkCore.Storage;

namespace POS.Repositories.PurchaseOrders
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(DataBaseContext context) : base(context)
        {

        }

        public override async Task<ResponseData<PurchaseOrder>> GetPagination(IRequestData requestData)
        {
            ExtendedRequestData eRequestData = requestData as ExtendedRequestData;
            int count = await DatabaseContext.PurchaseOrders.CountAsync();

            var items = DatabaseContext.PurchaseOrders
                .Include(p => p.Supplier)
                .Where(p=>p.Status!=PoStatus.Completed)
                .Where(p => EF.Functions.Like(p.Code, $"{requestData.Filter}%"));

            if(eRequestData.From.HasValue)
            {
                items = items.Where(p => p.Date >= eRequestData.From);
            }

            if(eRequestData.To.HasValue)
            {
                items = items.Where(p => p.Date <= eRequestData.To);
            }

            IEnumerable<PurchaseOrder> result =await items
                .Skip((eRequestData.Page - 1) * eRequestData.PageSize)
                .Take(eRequestData.PageSize)
                .ToListAsync();
            return new ResponseData<PurchaseOrder>(requestData.Page, requestData.PageSize, count, result);
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

        public async Task<PurchaseOrder> GetLastPurchaseOrder()
        {
            return await DatabaseContext.PurchaseOrders.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
