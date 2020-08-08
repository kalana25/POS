using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.GoodReceivedNotes
{
    public class GoodReceivedNoteRepository:Repository<GoodReceivedNote>, IGoodReceivedNoteRepository
    {
        public GoodReceivedNoteRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task<GoodReceivedNote> GetGoodReceivedNoteWithFullInfo(int id)
        {
            return await DatabaseContext.GoodReceivedNotes
                .Include(g => g.PurchaseOrder)
                .Include(g => g.Items)
                .ThenInclude(i => i.PurchaseOrderDetail)
                .Include(g => g.Items)
                .ThenInclude(i => i.Unit)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<GoodReceivedNote> GetLastGoodReceivedNote()
        {
            return await DatabaseContext.GoodReceivedNotes.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
