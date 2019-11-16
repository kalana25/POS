using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AgendaWeb.DAL;
using AgendaWeb.Repositories.Addresses;
using AgendaWeb.Repositories.Communications;
using AgendaWeb.Repositories.Collaborators;

namespace AgendaWeb.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;
        public IAddressRepository Addresses { get; set; }
        public ICommunicationRepository Communications { get; set; }
        public ICollaboratorRepository Collaborators { get; set; }


        public UnitOfWork(DataBaseContext context,
            IAddressRepository addressRepository,
            ICollaboratorRepository collaboratorRepository,
            ICommunicationRepository communicationRepository)
        {
            this.context = context;
            Addresses = addressRepository;
            Communications = communicationRepository;
            Collaborators = collaboratorRepository;
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
