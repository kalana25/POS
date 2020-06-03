using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.BaseUnits
{
    public class BaseUnitRepository: Repository<BaseUnit>, IBaseUnitRepository
    {
        public BaseUnitRepository(DataBaseContext context):base(context)
        {

        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }

        public async Task<BaseUnit> GetBaseUnitWithPurchaseUnits(int id)
        {
            return await DatabaseContext.BaseUnits
                .Include(b => b.PurchaseUnits)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
