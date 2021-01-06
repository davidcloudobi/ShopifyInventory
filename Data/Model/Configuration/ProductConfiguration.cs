using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
           // builder.HasMany(x => x.Inventories).WithOne(x => x.Product);
            builder.HasMany(x => x.ProductPictures).WithOne(x => x.Product);
            builder.HasMany(x => x.SellItems).WithOne(x => x.Product);
            builder.HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandId);
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
            builder.HasOne(x => x.Business)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BusinessId);

            //############################################

            builder.HasMany(x => x.InventoryProducts).WithOne(x => x.Product);
        }
    }
}
