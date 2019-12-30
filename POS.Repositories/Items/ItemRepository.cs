using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;


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
    }
}
