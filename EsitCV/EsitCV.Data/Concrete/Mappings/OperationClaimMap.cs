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
    public class OperationClaimMap : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.ToTable("OperationClaims");

            builder.HasData(new OperationClaim()
            {
                ID = 1,
                Name = "Admin",
                CreatedDate = DateTime.Now,
            },
            new OperationClaim()
            {
                ID = 2,
                Name = "User",
                CreatedDate = DateTime.Now,
            },
            new OperationClaim()
            {
                ID = 3,
                Name = "Company",
                CreatedDate = DateTime.Now,
            });

            builder.ToTable("OperationClaims");
        }
    }
}
