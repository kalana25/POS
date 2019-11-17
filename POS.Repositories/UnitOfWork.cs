using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;
using POS.Repositories.Suppliers;

namespace POS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;

        public ISupplierRepository Suppliers { get; set; }


        public UnitOfWork(DataBaseContext context,
            ISupplierRepository supplierRepository)
        {
            this.context = context;
            Suppliers = supplierRepository;
        }

        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
