using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Data.Concrete.Mappings
{

    public class LanguageMap : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.Level).IsRequired();

            builder.HasOne<UserProfile>(a => a.UserProfile).WithMany(a => a.Languages).HasForeignKey(a => a.UserProfileID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("Languages");
        }
    }
}
