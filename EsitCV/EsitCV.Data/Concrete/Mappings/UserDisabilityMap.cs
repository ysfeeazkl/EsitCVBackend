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
    public class UserDisabilityMap : IEntityTypeConfiguration<UserDisability>
    {
        public void Configure(EntityTypeBuilder<UserDisability> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.UserId).IsRequired();

            builder.ToTable("UserDisabilities");
        }
    }
}
