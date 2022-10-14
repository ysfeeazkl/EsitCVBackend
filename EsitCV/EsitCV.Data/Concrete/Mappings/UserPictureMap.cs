using EsitCV.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Data.Concrete.Mappings
{
  

    public class UserPictureMap : IEntityTypeConfiguration<UserPicture>
    {
        public void Configure(EntityTypeBuilder<UserPicture> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.Property(a => a.FileName).IsRequired();
            builder.Property(a => a.FileUrl).IsRequired();

            builder.ToTable("UserPictures");
        }
    }
}
