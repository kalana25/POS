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

        Task<PurchaseOrder> GetPurchaseOrderWithDetails(int id);
        Task<PurchaseOrder> GetPurchaseOrderWithFullInfo(int id);
        Task<PurchaseOrder> GetLastPurchaseOrder();
        //Task<IEnumerable<PurchaseOrder>> GetPurchaseOrders();
    }
}
