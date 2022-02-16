using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SmartphoneShop.Models;

namespace SmartphoneShop.Data
{

    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) :
       base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreSmartphone> StoreSmartphones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Smartphone>().ToTable("Smartphone");
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<StoreSmartphone>().ToTable("StoreSmartphone");

            modelBuilder.Entity<StoreSmartphone>()
                .HasKey(c => new { c.SmartphoneID, c.StoreID }); //configureaza cheia primara compusa
        }
    }
}

