﻿using EsitCV.Entities.Concrete;
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


    public class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.InstitutionName).IsRequired();
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(500);
            builder.Property(u => u.Activity).IsRequired();
            builder.Property(u => u.Degree).IsRequired();
            builder.Property(u => u.EducationCategory).IsRequired();

            builder.HasOne<UserProfile>(a => a.UserProfile).WithMany(a => a.Educations).HasForeignKey(a => a.UserProfileID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("Educations");
        }
    }
}
