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

        public async Task<IEnumerable<ItemCategory>> GetItemCategoriesByLevel(int level)
        {
            return await DatabaseContext.Categories.Where(x => x.Level == level).ToListAsync();
        }

        public async Task<IEnumerable<ItemCategory>> GetItemCategoriesByParentAndLevel(int parent, int level)
        {
            return await DatabaseContext.Categories.Where(x => x.Level == level && x.ParentCategoryId==parent).ToListAsync();
        }

        public async Task<ItemCategory> GetItemCategory(int id)
        {
            return await DatabaseContext.Categories.FindAsync(id);
        }

        public async Task<int> GetLastItemCategoryId()
        {
            return await DatabaseContext.Categories.OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
