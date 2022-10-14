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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(15);
            builder.Property(u => u.EmailAddress).IsRequired();
            builder.Property(u => u.EmailAddress).HasMaxLength(80);

            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnType("VARBINARY(500)");

            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");

            builder.HasOne<CurriculumVitae>(a => a.CurriculumVitae).WithOne(a => a.User).HasForeignKey<CurriculumVitae>(c => c.UserID);
            builder.HasOne<UserPicture>(a => a.UserPicture).WithOne(a => a.User).HasForeignKey<UserPicture>(c => c.UserID);
            builder.HasOne<UserDisability>(a => a.UserDisability).WithOne(a => a.User).HasForeignKey<UserDisability>(c => c.UserId);
            builder.HasOne<UserProfile>(a => a.UserProfile).WithOne(a => a.User).HasForeignKey<UserProfile>(c => c.UserID);
            builder.ToTable("Users");
        }
    }
}
