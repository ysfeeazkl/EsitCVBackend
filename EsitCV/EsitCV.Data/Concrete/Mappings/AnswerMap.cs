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
  

    public class AnswerMap : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Content).IsRequired();
            builder.Property(u => u.Content).HasMaxLength(200);

            builder.HasOne<JobApplication>(a => a.JobApplication).WithMany(a => a.Answers).HasForeignKey(a => a.JobApplicationID).OnDelete(DeleteBehavior.NoAction);
            //builder.HasOne<JobPosting>(a => a.JobPosting).WithMany(a => a.Questions).HasForeignKey(a => a.JobPostingID).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Question>(a => a.Question).WithMany(a => a.Answers).HasForeignKey(a => a.QuestionID).OnDelete(DeleteBehavior.NoAction);
            builder.ToTable("Answers");
        }
    }
}
