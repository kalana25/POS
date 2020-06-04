﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;
using POS.Core.General;


namespace POS.Repositories.PurchaseUnits
{
    public class PurchaseUnitRepository:Repository<PurchaseUnit>,IPurchaseUnitRepository
    {
        public PurchaseUnitRepository(DataBaseContext context) : base(context)
        {

        }

        public override async Task<ResponseData<PurchaseUnit>> GetPagination(RequestData requestData)
        {
            int count = await DatabaseContext.PurchaseUnits.CountAsync();
            IEnumerable<PurchaseUnit> items = await DatabaseContext.PurchaseUnits
                .Include(d => d.BaseUnit)
                .Include(d=>d.Item)
                .Skip((requestData.Page - 1) * requestData.PageSize)
                .Take(requestData.PageSize)
                .ToListAsync();
            return new ResponseData<PurchaseUnit>(requestData.Page, requestData.PageSize, count, items);
        }

        public override async Task<IEnumerable<PurchaseUnit>> GetAll()
        {
            return await DatabaseContext.PurchaseUnits
                .Include(p => p.BaseUnit)
                .Include(p => p.Item)
                .ToListAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
