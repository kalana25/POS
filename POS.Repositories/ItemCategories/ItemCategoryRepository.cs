using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.ItemCategories
{
    public class ItemCategoryRepository:Repository<ItemCategory>,IItemCategoryRepository
    {
        public ItemCategoryRepository(DataBaseContext context):base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }

        public async Task<IEnumerable<ItemCategory>> GetItemCategories()
        {
            return await DatabaseContext.Categories.ToListAsync();
        }

        public async Task<ItemCategory> GetItemCategory(int id)
        {
            return await DatabaseContext.Categories.FindAsync(id);
        }
    }
}
