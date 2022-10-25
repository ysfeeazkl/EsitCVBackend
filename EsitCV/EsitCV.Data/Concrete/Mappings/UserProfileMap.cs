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
 
    public class UserProfileMap : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();

            builder.HasOne<About>(a => a.About).WithOne(a => a.UserProfile).HasForeignKey<About>(c => c.UserProfileID);

            builder.ToTable("UserProfiles");
        }
    }
}
