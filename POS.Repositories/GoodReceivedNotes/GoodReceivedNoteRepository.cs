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

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
