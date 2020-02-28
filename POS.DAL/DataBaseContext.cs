using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using POS.Models;

namespace POS.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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


        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        

    }
}
