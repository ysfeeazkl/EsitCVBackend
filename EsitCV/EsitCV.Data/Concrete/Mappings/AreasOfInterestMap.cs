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

    public class AreasOfInterestMap : IEntityTypeConfiguration<AreasOfInterest>
    {
        public void Configure(EntityTypeBuilder<AreasOfInterest> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50);

            builder.HasOne<UserProfile>(a => a.UserProfile).WithMany(a => a.AreasOfInterests).HasForeignKey(a => a.UserProfileID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("AreasOfInterests");
        }
    }
}
