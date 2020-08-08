using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using POS.Models;
using System.Linq;
using POS.Core.DI;
namespace POS.Repositories.GoodReceivedNotes
{
    [AutoDIService]
    public interface IGoodReceivedNoteRepository : IRepository<GoodReceivedNote>
    {
        Task<GoodReceivedNote> GetLastGoodReceivedNote();
        Task<GoodReceivedNote> GetGoodReceivedNoteWithFullInfo(int id);
    }
}
