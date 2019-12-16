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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ItemCategory> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    }
}
