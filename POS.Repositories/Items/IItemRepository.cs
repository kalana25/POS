using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;
using System.Collections.Generic;

namespace POS.Repositories.Items
{
    [AutoDIService]
    public interface IItemRepository:IRepository<Item>
    {
        Task<Item> GetItem(int id);
        Task<IEnumerable<Item>> GetItems();
    }
}
