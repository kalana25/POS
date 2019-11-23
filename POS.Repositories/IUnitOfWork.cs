using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Repositories.Items;
using POS.Repositories.Suppliers;
using POS.Repositories.ItemCategories;
using POS.Core.DI;


namespace POS.Repositories
{
    [AutoDIService(implementationType: "POS.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }
        IItemCategoryRepository ItemCategory { get; }
        IItemRepository Item { get; }
        Task<int> Complete();
    }
}
