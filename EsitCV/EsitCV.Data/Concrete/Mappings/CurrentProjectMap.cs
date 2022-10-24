﻿using EsitCV.Entities.Concrete.Features;
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

    public class CurrentProjectMap : IEntityTypeConfiguration<CurrentProject>
    {
        public void Configure(EntityTypeBuilder<CurrentProject> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(500);
            builder.Property(u => u.ProjectUrl).IsRequired();

            builder.HasOne<UserProfile>(a => a.UserProfile).WithMany(a => a.CurrentProjects).HasForeignKey(a => a.UserProfileID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("CurrentProjects");
        }
    }
}
