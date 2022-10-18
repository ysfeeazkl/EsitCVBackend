using EsitCV.Entities.Concrete;
using EsitCV.Entities.Concrete.Disableds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Data.Concrete.Mappings
{
    public class UserAndDisabilityMap : IEntityTypeConfiguration<UserAndDisability>
    {
        public void Configure(EntityTypeBuilder<UserAndDisability> builder)
        {
            builder.HasKey(a => new { a.UserID, a.DisabilityID});
            builder.Property(a => a.PercentageOfDisability).IsRequired();
            builder.Property(a => a.PercentageOfDisability).HasMaxLength(100);

            builder.HasOne<User>(uo => uo.User).WithMany(u => u.UserAndDisabilities).HasForeignKey(uo => uo.UserID);
            builder.HasOne<Disability>(a => a.Disability).WithMany(a => a.UserAndDisabilities).HasForeignKey(a => a.DisabilityID);

            builder.ToTable("UserAndDisabilities");
        }
    }
}
