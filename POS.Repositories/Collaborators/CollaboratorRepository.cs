using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AgendaWeb.Models;
using System.Linq;
using AgendaWeb.DAL;
using Microsoft.EntityFrameworkCore;

namespace AgendaWeb.Repositories.Collaborators
{
    public class CollaboratorRepository : Repository<Collaborator>, ICollaboratorRepository
    {
        public CollaboratorRepository(DbContext context):base(context)
        {

        }
        public async Task<IEnumerable<Collaborator>> GetAllCollaboratorsWithFullInfo()
        {
            return await DatabaseContext.Collaborators
                .Include(c => c.Address)
                .Include(c => c.Communication)
                .OrderBy(c => c.LastName)
                .ToListAsync();
        }

        public async Task<Collaborator> GetCollaboratorWithFullInfor(int id)
        {
            return await DatabaseContext.Collaborators
                .Include(p => p.Address)
                .Include(p => p.Communication)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Collaborator>> GetPaginatedCollaboratorsWithFullInfo(int pageIndex, int pageSize)
        {
            return await DatabaseContext.Collaborators
                .Include(p => p.Communication)
                .Include(p => p.Address)
                .OrderBy(s => s.LastName)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
