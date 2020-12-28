using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
   {
       public void Configure(EntityTypeBuilder<ApplicationUser> builder)
       {
           builder.Property(x => x.FullName).IsRequired();
           builder.HasOne(x => x.Business)
               .WithMany(x => x.ApplicationUsers)
               .HasForeignKey(x => x.BusinessId);
           //builder.HasMany(x => x.Sells).WithOne(x => x.ApplicationUser);
       }
   }
}
