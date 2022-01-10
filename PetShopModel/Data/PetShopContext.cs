using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetShopModel.Models;

namespace PetShopModel.Data
{
    public class PetShopContext : DbContext
    {
        public PetShopContext(DbContextOptions<PetShopContext> options) :
        base(options)
        {
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SuppliedProduct> SuppliedProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
            modelBuilder.Entity<SuppliedProduct>().ToTable("SuppliedProduct");
            modelBuilder.Entity<SuppliedProduct>()
            .HasKey(c => new { c.ProductID, c.SupplierID });
        }
    }
}
