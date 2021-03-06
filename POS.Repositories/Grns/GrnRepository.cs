﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;
using POS.Core.General;

namespace POS.Repositories.Grns
{
    public class GrnRepository:Repository<GoodReceivedNote>,IGrnRepository
    {
        public GrnRepository(DataBaseContext context) : base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }

        public override async Task<ResponseData<GoodReceivedNote>> GetPagination(IRequestData requestData)
        {
            int count = await DatabaseContext.GoodReceivedNotes.CountAsync();
            IEnumerable<GoodReceivedNote> grns = await DatabaseContext.GoodReceivedNotes
                .Include(g=>g.PurchaseOrder)
                .Skip((requestData.Page - 1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<GoodReceivedNote>(requestData.Page, requestData.PageSize, count, grns);
        }
    }
}
