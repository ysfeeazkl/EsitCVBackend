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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.TaxNumber).IsRequired();
            builder.Property(u => u.TaxNumber).HasMaxLength(10);
            builder.Property(u => u.Sector).IsRequired();
            builder.Property(u => u.Sector).HasMaxLength(30);
            builder.Property(u => u.EmailAddress).IsRequired();
            builder.Property(u => u.EmailAddress).HasMaxLength(80);

            builder.Property(u => u.PasswordSalt).IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnType("VARBINARY(500)");

            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");

            builder.HasOne<CompanyPicture>(a => a.CompanyPicture).WithOne(a => a.Company).HasForeignKey<CompanyPicture>(c => c.CompanyID).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne<Location>(a => a.Location).WithOne(a => a.Company).HasForeignKey<Location>(c => c.CompanyID);

            builder.ToTable("Companies");
        }
    }
}
