using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Core.DI;
using POS.Models;

namespace POS.Repositories.Collaborators
{
    [AutoDIService]
    public interface ICollaboratorRepository: IRepository<Collaborator>
    {
        Task<Collaborator> GetCollaboratorWithFullInfor(int id);
        Task<IEnumerable<Collaborator>> GetAllCollaboratorsWithFullInfo();
        Task<IEnumerable<Collaborator>> GetPaginatedCollaboratorsWithFullInfo(int pageIndex, int pageSize);
    }
}
