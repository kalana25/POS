using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public DataBaseContext DatabaseContext
        {
            get { return context as DataBaseContext; }
        }
    }
}
