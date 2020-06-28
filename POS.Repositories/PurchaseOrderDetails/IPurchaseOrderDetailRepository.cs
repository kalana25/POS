using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using System.Linq;
using POS.Core.DI;

namespace POS.Repositories.PurchaseOrderDetails
{
    [AutoDIService]
    public interface IPurchaseOrderDetailRepository : IRepository<PurchaseOrderDetail>
    {
        Task<IEnumerable<PurchaseOrderDetail>> GetPurchaseOrderDetailsWithFullInfo(int purchaseOrderId);
    }
}
