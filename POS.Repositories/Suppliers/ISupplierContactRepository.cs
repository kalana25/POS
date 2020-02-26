using POS.Core.DI;
using POS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Repositories.Suppliers
{
    [AutoDIService]
    public interface ISupplierContactRepository : IRepository<SupplierContact>
    {
    }
}
