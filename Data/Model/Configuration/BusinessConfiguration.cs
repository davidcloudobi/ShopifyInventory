using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class BusinessConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ContactName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.HasMany(x => x.Outlets).WithOne(x => x.Business);
            builder.HasMany(x => x.ApplicationUsers).WithOne(x => x.Business);
            builder.HasMany(x => x.Inventories).WithOne(x => x.Business);
            builder.HasMany(x => x.Products).WithOne(x => x.Business);
            builder.HasMany(x => x.Sells).WithOne(x => x.Business);
            builder.HasOne(x => x.BusinessType)
                .WithMany(x => x.Businesses)
                .HasForeignKey(x => x.BusinessTypeId);
            builder.HasMany(x => x.Brands).WithOne(x => x.Business);
            builder.HasMany(x => x.Categories).WithOne(x => x.Business);

        }
    }
}
