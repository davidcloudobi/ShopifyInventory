using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
  public  class SellItemConfiguration : IEntityTypeConfiguration<SellItem>
    {
        public void Configure(EntityTypeBuilder<SellItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PriceSold).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Sell)
                .WithMany(x => x.SellItems)
                .HasForeignKey(x => x.SellId);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.SellItems)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
