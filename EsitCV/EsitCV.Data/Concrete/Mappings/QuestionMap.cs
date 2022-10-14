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
    public class QuestionMap : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(200);

            builder.HasOne<JobPosting>(a => a.JobPosting).WithMany(a => a.Questions).HasForeignKey(a => a.JobPostingID).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Questions");
        }
    }
}
