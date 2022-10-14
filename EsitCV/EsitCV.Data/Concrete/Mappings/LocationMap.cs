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

    public class LocationMap : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
          
            builder.Property(u => u.Country).IsRequired();
            builder.Property(u => u.Country).HasMaxLength(20);
            builder.Property(u => u.Province).IsRequired();
            builder.Property(u => u.Province).HasMaxLength(30);
            builder.Property(u => u.District).IsRequired();
            builder.Property(u => u.District).HasMaxLength(30);

           //builder.HasOne<Company>(a => a.Company).WithOne(a => a.Location).HasForeignKey<Company>(c => c.LocationID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("Locations");
        }
    }
}
