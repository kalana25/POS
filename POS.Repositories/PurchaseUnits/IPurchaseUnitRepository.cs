using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;

namespace POS.Repositories.PurchaseUnits
{
    [AutoDIService]
    public interface IPurchaseUnitRepository:IRepository<PurchaseUnit>
    {
        Task<IEnumerable<PurchaseUnit>> GetByItem(int itemId);
        Task<int> GetLastPurchaseUnitId();
    }
}
