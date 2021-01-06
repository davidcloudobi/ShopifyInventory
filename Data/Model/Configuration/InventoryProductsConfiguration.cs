using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class InventoryProductsConfiguration : IEntityTypeConfiguration<InventoryProduct>
    {
        public void Configure(EntityTypeBuilder<InventoryProduct> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Inventory)
                .WithMany(x => x.InventoryProducts)
                .HasForeignKey(x => x.InventoryId);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.InventoryProducts)
                .HasForeignKey(x => x.ProductId);


        }
    }
}
