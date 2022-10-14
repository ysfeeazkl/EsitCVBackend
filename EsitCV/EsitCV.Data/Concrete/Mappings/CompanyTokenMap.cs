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
    public class CompanyTokenMap : IEntityTypeConfiguration<CompanyToken>
    {
        public void Configure(EntityTypeBuilder<CompanyToken> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Token).IsRequired();
            builder.Property(a => a.TokenExpiration).IsRequired();
            builder.Property(a => a.CompanyID).IsRequired();

            builder.HasOne<Company>(a => a.Company).WithMany(a => a.CompanyTokens).HasForeignKey(a => a.CompanyID);
            builder.ToTable("CompanyTokens");
        }
    }
}
