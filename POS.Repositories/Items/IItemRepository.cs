﻿using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;
using POS.Core.General;
using System.Collections.Generic;

namespace POS.Repositories.Items
{
    [AutoDIService]
    public interface IItemRepository:IRepository<Item>
    {
        Task<Item> GetItem(int id);
        Task<IEnumerable<Item>> GetItems();
        Task<IEnumerable<Item>> GetItemsByLevel(int level);
        Task<IEnumerable<Item>> GetItemsByCategoyry(int category);
        Task<int> GetLastItemId();
    }
}
