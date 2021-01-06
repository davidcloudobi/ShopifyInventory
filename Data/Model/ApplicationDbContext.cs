using System;
using System.Collections.Generic;
using System.Text;
using Data.Model.Configuration;
using Data.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Model
{
  public  class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Outlet> Outlets { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<SellItem> SellItems { get; set; }

        public DbSet<InventoryProduct> InventoryProducts { get; set; }
       // public DbSet<BusinessCustomer> BusinessCustomers { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationRoleConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new OutletConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPictureConfiguration());
            modelBuilder.ApplyConfiguration(new SellConfiguration());
            modelBuilder.ApplyConfiguration(new SellItemConfiguration());
        }

    }
}
