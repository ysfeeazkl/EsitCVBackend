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

    public class CompanyAndOperationClaimMap : IEntityTypeConfiguration<CompanyAndOperationClaim>
    {
        public void Configure(EntityTypeBuilder<CompanyAndOperationClaim> builder)
        {
            builder.HasKey(a => new { a.CompanyID, a.OperationClaimID });
            builder.HasOne<Company>(uo => uo.Company).WithMany(u => u.CompanyAndOperationClaims).HasForeignKey(uo => uo.CompanyID);
            builder.HasOne<OperationClaim>(a => a.OperationClaim).WithMany(a => a.CompanyAndOperationClaims).HasForeignKey(a => a.OperationClaimID);

            builder.ToTable("CompanyAndOperationClaims");
        }
    }

}
