using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Repositories.Items;
using POS.Repositories.Suppliers;
using POS.Repositories.ItemCategories;
using POS.Repositories.PurchaseOrders;
using POS.Repositories.PurchaseOrderDetails;
using POS.Core.DI;


namespace POS.Repositories
{
    [AutoDIService(implementationType: "POS.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }
        ISupplierContactRepository SupplierContacts { get; }
        IItemCategoryRepository ItemCategories { get; }
        IItemRepository Items { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        IPurchaseOrderDetailRepository PurchaseOrderDetails { get; }
        Task<int> Complete();
    }
}
