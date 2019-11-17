using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.Repositories.Addresses;
using POS.Repositories.Communications;
using POS.Repositories.Collaborators;
using POS.Repositories.Suppliers;
using POS.Core.DI;


namespace POS.Repositories
{
    [AutoDIService(implementationType: "POS.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        ICommunicationRepository Communications { get; }
        ICollaboratorRepository Collaborators { get; }
        ISupplierRepository Suppliers { get; }
        Task<int> Complete();
    }
}
