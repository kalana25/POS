using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;

namespace POS.Repositories.ItemCategories
{
    [AutoDIService]
    public interface IItemCategoryRepository:IRepository<ItemCategory>
    {
        Task<IEnumerable<ItemCategory>> GetItemCategories();
        Task<IEnumerable<ItemCategory>> GetItemCategoriesByLevel(int level);
        Task<IEnumerable<ItemCategory>> GetItemCategoriesByParentAndLevel(int parent,int level);
        Task<ItemCategory> GetItemCategory(int id);
        Task<int> GetLastItemCategoryId();
    }
}