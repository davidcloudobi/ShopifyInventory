using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class SellConfiguration : IEntityTypeConfiguration<Sell>
    {
        public void Configure(EntityTypeBuilder<Sell> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalCost).IsRequired();
            builder.Property(x => x.TransactionDate).IsRequired();
            builder.HasMany(x => x.SellItems).WithOne(x => x.Sell);
            builder.HasOne(x => x.Outlet)
                .WithMany(x => x.Sells)
                .HasForeignKey(x => x.OutletId);
            //builder.HasOne(x => x.ApplicationUser)
            //    .WithMany(x => x.Sells)
            //    .HasForeignKey(x => x.ApplicationUserId);
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Sells)
                .HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.PaymentType)
                .WithMany(x => x.Sells)
                .HasForeignKey(x => x.PaymentTypeId);
            builder.HasOne(x => x.Business)
                .WithMany(x => x.Sells)
                .HasForeignKey(x => x.BusinessId);
        }
    }
}
