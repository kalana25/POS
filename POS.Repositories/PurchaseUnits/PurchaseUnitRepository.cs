using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;


namespace POS.Repositories.PurchaseUnits
{
    public class PurchaseUnitRepository:Repository<PurchaseUnit>,IPurchaseUnitRepository
    {
        public PurchaseUnitRepository(DataBaseContext context) : base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
