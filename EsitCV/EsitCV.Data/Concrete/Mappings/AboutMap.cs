using EsitCV.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;

namespace EsitCV.Data.Concrete.Mappings
{

    public class AboutMap : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(500);

            //builder.HasOne<UserProfile>(a => a.UserProfile).WithOne(a => a.About).HasForeignKey<About>(c => c.UserProfileID);


            builder.ToTable("Abouts");
        }
    }
}
