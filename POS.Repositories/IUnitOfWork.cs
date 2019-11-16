using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendaWeb.Repositories.Addresses;
using AgendaWeb.Repositories.Communications;
using AgendaWeb.Repositories.Collaborators;
using AgendaWeb.Core.DI;


namespace AgendaWeb.Repositories
{
    [AutoDIService(implementationType: "AgendaWeb.Repositories.UnitOfWork")]
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        ICommunicationRepository Communications { get; }
        ICollaboratorRepository Collaborators { get; }
        Task<int> Complete();
    }
}
