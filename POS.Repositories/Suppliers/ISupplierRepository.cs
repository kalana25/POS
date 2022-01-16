using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using POS.Core.DI;

namespace POS.Repositories.Suppliers
{
    [AutoDIService]
    public interface ISupplierRepository:IRepository<Supplier>
    {
        Task<Supplier> GetSupplier(int id);
        Task<IEnumerable<Supplier>> GetSuppliersWithContacts();
        Task<int> GetLastSupplierId();
    }
}
