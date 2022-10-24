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
    public class WorkExperienceMap : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.CompanyName).IsRequired();
            //builder.Property(u => u.CompanyID).IsRequired();
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(500);
            builder.Property(u => u.Title).IsRequired();
            builder.Property(u => u.Activity).IsRequired();
            builder.Property(u => u.Degree).IsRequired();
            builder.Property(u => u.EducationCategory).IsRequired();
            //builder.Property(u => u.Currently).IsRequired();

            builder.HasOne<UserProfile>(a => a.UserProfile).WithMany(a => a.WorkExperiences).HasForeignKey(a => a.UserProfileID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("WorkExpreriences");
        }
    }
}
