using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;
using POS.Repositories.Suppliers;
using POS.Repositories.ItemCategories;
using POS.Repositories.Items;

namespace POS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;

        public ISupplierRepository Suppliers { get; set; }
        public IItemCategoryRepository ItemCategories { get; set; }
        public IItemRepository Items { get; set; }


        public UnitOfWork(DataBaseContext context,
            ISupplierRepository supplierRepository,
            IItemCategoryRepository itemCategoryRepository,
            IItemRepository itemRepository)
        {
            this.context = context;
            Suppliers = supplierRepository;
            ItemCategories = itemCategoryRepository;
            Items = itemRepository;
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
