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
    public class JobApplicationMap : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();

            builder.HasOne<User>(a => a.User).WithMany(a => a.JobApplications).HasForeignKey(a => a.UserID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<JobPosting>(a => a.JobPosting).WithMany(a => a.JobApplications).HasForeignKey(a => a.JobPostingID).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("JobPostings");
        }
    }
}
