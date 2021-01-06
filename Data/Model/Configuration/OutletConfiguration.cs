using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class OutletConfiguration : IEntityTypeConfiguration<Outlet>
    {
        public void Configure(EntityTypeBuilder<Outlet> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.DateAdded).IsRequired();
            builder.HasOne(x => x.Business).WithMany(x => x.Outlets).HasForeignKey(x => x.BusinessId);
          //  builder.HasMany(x => x.Inventories).WithOne(x => x.Outlet);
           
            builder.HasMany(x => x.Sells).WithOne(x => x.Outlet);

            builder.HasOne(x => x.Inventory).WithOne(x => x.Outlet).HasForeignKey<Inventory>(x=>x.OutletId);
        }
    }
}
