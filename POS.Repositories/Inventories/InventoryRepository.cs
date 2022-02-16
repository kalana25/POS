using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models.StoredProcedureModels;
using POS.Models;
using POS.Core.General;

namespace POS.Repositories.Inventories
{
    public class InventoryRepository:Repository<Inventory>,IInventoryRepository
    {
        public InventoryRepository(DataBaseContext context) : base(context)
        {

        }

        public override async Task<ResponseData<Inventory>> GetPagination(IRequestData requestData)
        {
            int count = await DatabaseContext.Inventories.CountAsync();

            var items = DatabaseContext.Inventories
                .Include(p => p.Item)
                .Include(p => p.Unit);

            IEnumerable<Inventory> result = await items
                .Skip((requestData.Page - 1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<Inventory>(requestData.Page, requestData.PageSize, count, result);
        }

        public async Task<Inventory> GetInventoryWithDetailsByItem(int inventoryId)
        {
            return await DatabaseContext.Inventories
                .Include(x=>x.Item)
                .Include(x=>x.Unit)
                .Include(i => i.Details)
                .ThenInclude(d=>d.Unit)
                .Include(i=>i.Details)
                .ThenInclude(g=>g.GoodReceivedNote)
                .FirstOrDefaultAsync(x => x.Id == inventoryId);
        }

        /// <summary>
        /// Fetch Unique Items in the current stock for given category
        /// </summary>
        /// <param name="categoryId">item category Id</param>
        /// <returns>UniqueStockItemByCategory</returns>
        public async Task<IEnumerable<UniqueStockItemByCategory>> GetInventoryByCategoryId(int categoryId)
        {
            return await DatabaseContext
                .UniqueStockItems
                .FromSqlInterpolated($"EXECUTE SP_UniqueStockItemsByCategory {categoryId}")
                .ToListAsync();
        }

        public async Task<Inventory> GetInventoryWithDetailsByItemAndPrices(int itemId, decimal purchasePrice, decimal sellingPrice)
        {
            return await DatabaseContext.Inventories
                .Include(x => x.Item)
                .Include(x => x.Unit)
                .Include(i => i.Details)
                .ThenInclude(d => d.Unit)
                .Include(i => i.Details)
                .ThenInclude(g => g.GoodReceivedNote)
                .FirstOrDefaultAsync(x => x.ItemId == itemId && x.SellingPricePerBaseUnit==sellingPrice && x.PurchasingPricePerBaseUnit==purchasePrice);
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
