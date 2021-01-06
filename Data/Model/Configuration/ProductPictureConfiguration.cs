using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Configuration
{
   public class ProductPictureConfiguration : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Url).IsRequired();
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
