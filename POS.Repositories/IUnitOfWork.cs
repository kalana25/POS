using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Repositories.Suppliers;
using POS.Core.DI;


namespace POS.Repositories
{
    [AutoDIService(implementationType: "POS.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        ISupplierRepository Suppliers { get; }
        Task<int> Complete();
    }
}
