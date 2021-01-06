using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();
            //builder.HasOne(x => x.Business)
            //    .WithMany(x => x.Inventories)
            //    .HasForeignKey(x => x.BusinessId);
            //builder.HasOne(x => x.Outlet)
            //    .WithMany(x => x.Inventories)
            //    .HasForeignKey(x => x.OutletId);
            //builder.HasOne(x => x.Product)
            //    .WithMany(x => x.Inventories)
            //    .HasForeignKey(x => x.ProductId);
            builder.HasMany(x => x.InventoryProducts)
                .WithOne(x => x.Inventory);

        }
    }
}
