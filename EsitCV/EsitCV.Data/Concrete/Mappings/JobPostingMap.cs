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

    public class JobPostingMap : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Header).IsRequired();
            builder.Property(u => u.Header).HasMaxLength(100);
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(500);
            builder.Property(u => u.Sector).IsRequired();
            builder.Property(u => u.Sector).HasMaxLength(40);
            builder.Property(u => u.JobPosition).IsRequired();
            builder.Property(u => u.JobPosition).HasMaxLength(80);
            builder.Property(u => u.LicenceDegree).IsRequired();
            builder.Property(u => u.LicenceDegree).HasMaxLength(40);
            builder.Property(u => u.Language).IsRequired();
            builder.Property(u => u.Language).HasMaxLength(30);

            builder.HasOne<Company>(a => a.Company).WithMany(a => a.JobPostings).HasForeignKey(a => a.CompanyID).OnDelete(DeleteBehavior.NoAction);


            builder.ToTable("JobPostings");
        }
    }
}
