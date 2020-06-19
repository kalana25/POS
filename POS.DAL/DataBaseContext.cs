 using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using POS.Models;

namespace POS.DAL
{
    public class DataBaseContext : IdentityDbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Restict auto delete items when a category is deleted.
            modelBuilder.Entity<ItemCategory>()
                .HasMany(c => c.Items)
                .WithOne(i => i.ItemCateogry)
                .OnDelete(DeleteBehavior.Restrict);

            //Restict auto delete PurchaseOderDetails when a PurchaseOrder is deleted.
            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(h => h.Items)
                .WithOne(d => d.PurchaseOrder)
                .OnDelete(DeleteBehavior.Restrict);

            //Restict auto delete GoodReceivedNoteItems when a GoodReceivedNote is deleted.
            modelBuilder.Entity<GoodReceivedNote>()
                .HasMany(h => h.Items)
                .WithOne(d => d.GoodReceivedNote)
                .OnDelete(DeleteBehavior.Restrict);

            //Restict auto delete GoodReceivedNoteItems when a PurchaseOrderDetail is deleted.
            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasMany(p => p.GoodReceivedNoteItems)
                .WithOne(g => g.PurchaseOrderDetail)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.PurchaseOrders)
                .WithOne(p => p.Supplier)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BaseUnit>()
                .HasMany(bu => bu.PurchaseUnits)
                .WithOne(pu => pu.BaseUnit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.PurchaseUnits)
                .WithOne(pu => pu.Item)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventory>()
                .HasMany(i => i.Details)
                .WithOne(id => id.Inventory)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Unit>()
                .HasMany(u => u.InventoryDetails)
                .WithOne(id => id.Unit)
                .OnDelete(DeleteBehavior.Restrict);


        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierContact> SupplierContacts { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<GoodReceivedNote> GoodReceivedNotes { get; set; }
        public DbSet<GoodReceivedNoteItem> GoodReceivedNoteItems { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryDetail> InventoryDetail { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<BaseUnit> BaseUnits { get; set; }
        public DbSet<PurchaseUnit> PurchaseUnits { get; set; }

    }
}
