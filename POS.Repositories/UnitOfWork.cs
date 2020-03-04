using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using POS.DAL;
using POS.Repositories.Suppliers;
using POS.Repositories.ItemCategories;
using POS.Repositories.Items;
using POS.Repositories.PurchaseOrders;
using POS.Repositories.PurchaseOrderDetails;
using POS.Repositories.GoodReceivedNotes;

namespace POS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;

        public ISupplierRepository Suppliers { get; set; }
        public IItemCategoryRepository ItemCategories { get; set; }
        public IItemRepository Items { get; set; }
        public IPurchaseOrderRepository PurchaseOrders { get; set; }
        public IPurchaseOrderDetailRepository PurchaseOrderDetails { get; set; }
        public IGoodReceivedNoteRepository GoodReceivedNotes { get; set; }


        public UnitOfWork(DataBaseContext context,
            ISupplierRepository supplierRepository,
            IItemCategoryRepository itemCategoryRepository,
            IItemRepository itemRepository,
            IPurchaseOrderRepository purchaseOrderRepository,
            IPurchaseOrderDetailRepository purchaseOrderDetailsRepository,
            IGoodReceivedNoteRepository goodReceivedNoteRepository)
        {
            this.context = context;
            Suppliers = supplierRepository;
            ItemCategories = itemCategoryRepository;
            Items = itemRepository;
            PurchaseOrders = purchaseOrderRepository;
            PurchaseOrderDetails = purchaseOrderDetailsRepository;
            GoodReceivedNotes = goodReceivedNoteRepository;
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
