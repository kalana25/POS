using System.Threading.Tasks;
using POS.Models;
using POS.Models.StoredProcedureModels;
using POS.Core.DI;
using POS.Core.General;
using System.Collections.Generic;

namespace POS.Repositories.Inventories
{
    [AutoDIService]
    public interface IInventoryRepository:IRepository<Inventory>
    {
        Task<Inventory> GetInventoryWithDetailsByItem(int inventoryId);
        Task<Inventory> GetInventoryWithDetailsByItemAndPrices(int itemId, decimal purchasePrice, decimal sellingPrice);
        Task<IEnumerable<UniqueStockItemByCategory>> GetInventoryByCategoryId(int categoryId);
    }
}
