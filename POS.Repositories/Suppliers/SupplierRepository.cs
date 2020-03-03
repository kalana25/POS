using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using POS.DAL;
using POS.Models;

namespace POS.Repositories.Suppliers
{
    public class SupplierRepository:Repository<Supplier>,ISupplierRepository
    {
        public SupplierRepository(DataBaseContext context):base(context)
        {

        }

        public async Task<Supplier> GetSupplier(int id)
        {
            return await DatabaseContext.Suppliers.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliersWithContacts()
        {
            return await DatabaseContext.Suppliers.Where(x => x.Active == true).Include(x => x.SupplierContacts).Where(x => x.SupplierContacts.Any(z => z.Active == true)).ToListAsync();
        }

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
