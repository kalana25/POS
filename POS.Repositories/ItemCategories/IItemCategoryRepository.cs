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
        Task<ItemCategory> GetItemCategory(int id);
    }
}