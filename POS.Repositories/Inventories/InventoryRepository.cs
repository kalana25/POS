﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using POS.DAL;
using POS.Models;
using POS.Core.General;

namespace POS.Repositories.Inventories
{
    public class InventoryRepository:Repository<Inventory>,IInventoryRepository
    {
        public InventoryRepository(DataBaseContext context) : base(context)
        {

        }

        public async Task<Inventory> GetInventoryWithDetailsByItem(int itemId)
        {
            return await DatabaseContext.Inventories
                .Include(i => i.Details)
                .FirstOrDefaultAsync(x => x.ItemId == itemId);
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
