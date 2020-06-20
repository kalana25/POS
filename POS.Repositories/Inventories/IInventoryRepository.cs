using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;
using POS.Core.General;
using System.Collections.Generic;

namespace POS.Repositories.Inventories
{
    [AutoDIService]
    public interface IInventoryRepository:IRepository<Inventory>
    {
    }
}
