using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.PurchaseOrderDetails
{
    public class PurchaseOrderDetailRepository: Repository<PurchaseOrderDetail>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(DataBaseContext context):base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }

        public async Task<IEnumerable<PurchaseOrderDetail>> GetPurchaseOrderDetailsWithFullInfo(int purchaseOrderId)
        {
            return await DatabaseContext.PurchaseOrderDetails
                .Where(d => d.PurchaseOrderId == purchaseOrderId)
                .Include(d => d.Item)
                .Include(d => d.Unit)
                .ToListAsync();
        }
    }
}
