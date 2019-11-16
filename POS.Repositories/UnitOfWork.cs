using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;
using POS.Repositories.Addresses;
using POS.Repositories.Communications;
using POS.Repositories.Collaborators;

namespace POS.Repositories
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
