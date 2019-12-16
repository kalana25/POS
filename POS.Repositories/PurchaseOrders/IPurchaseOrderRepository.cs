using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using System.Linq;
using POS.Core.DI;

namespace POS.Repositories.PurchaseOrders
{
    [AutoDIService]
    public interface IPurchaseOrderRepository:IRepository<PurchaseOrder>
    {
        //Task<PurchaseOrder> GetPurchaseOrder(int id);
        //Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders();
    }
}
