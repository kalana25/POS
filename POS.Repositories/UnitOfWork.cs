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
using POS.Repositories.Discounts;
using POS.Repositories.BaseUnits;
using POS.Repositories.PurchaseUnits;

namespace POS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext context;

        public ISupplierRepository Suppliers { get; set; }
        public IItemCategoryRepository ItemCategories { get; set; }
        public IItemRepository Items { get; set; }
        public IPurchaseOrderRepository PurchaseOrders { get; set; }
        public ISupplierContactRepository SupplierContacts { get; set; }
        public IPurchaseOrderDetailRepository PurchaseOrderDetails { get; set; }
        public IGoodReceivedNoteRepository GoodReceivedNotes { get; set; }
        public IDiscountRepository Discounts { get; set; }
        public IBaseUnitRepository BaseUnits { get; set; }
        public IPurchaseUnitRepository PurchaseUnits { get; set; }

        public UnitOfWork(DataBaseContext context,
            ISupplierRepository supplierRepository,
            IItemCategoryRepository itemCategoryRepository,
            IItemRepository itemRepository,
            IPurchaseOrderRepository purchaseOrderRepository,
            IPurchaseOrderDetailRepository purchaseOrderDetailsRepository,
            ISupplierContactRepository supplierContactRepository,
            IGoodReceivedNoteRepository goodReceivedNoteRepository,
            IDiscountRepository discountRepository,
            IBaseUnitRepository baseUnits,
            IPurchaseUnitRepository purchaseUnits)
        {
            this.context = context;
            Suppliers = supplierRepository;
            ItemCategories = itemCategoryRepository;
            Items = itemRepository;
            PurchaseOrders = purchaseOrderRepository;
            PurchaseOrderDetails = purchaseOrderDetailsRepository;
            SupplierContacts = supplierContactRepository;
            GoodReceivedNotes = goodReceivedNoteRepository;
            Discounts = discountRepository;
            BaseUnits = baseUnits;
            PurchaseUnits = purchaseUnits;
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
