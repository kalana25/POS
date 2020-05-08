using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;
using POS.Core.General;

namespace POS.Repositories.Items
{
    public class ItemRepository:Repository<Item>,IItemRepository
    {
        public ItemRepository(DataBaseContext context) : base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }

        public async Task<Item> GetItem(int id)
        {
            return await DatabaseContext.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await DatabaseContext.Items.ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByLevel(int level)
        {
            return await DatabaseContext.Items.Where(x => x.ItemCateogry.Level == level).ToListAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsByCategoyry(int category)
        {
            return await DatabaseContext.Items.Where(x => x.CategoryId==category).ToListAsync();
        }

        public override async Task<ResponseData<Item>> GetPagination(RequestData requestData)
        {
            int count = await this.DatabaseContext.Items.CountAsync();
            IEnumerable<Item> items = await DatabaseContext.Items
                .Where(
                i=> EF.Functions.Like(i.Code,$"{requestData.Filter}%") 
                || EF.Functions.Like(i.Name,$"{requestData.Filter}%") 
                || EF.Functions.Like(i.Barcode,$"{requestData.Filter}%")
                )
                .Skip((requestData.Page - 1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<Item>(requestData.Page, requestData.PageSize, count, items);            
        }

    }
}
