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

    public class UserAndOperationClaimMap : IEntityTypeConfiguration<UserAndOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserAndOperationClaim> builder)
        {
            builder.HasKey(a => new { a.UserID, a.OperationClaimID });
            builder.HasOne<User>(uo => uo.User).WithMany(u => u.UserAndOperationClaims).HasForeignKey(uo => uo.UserID);
            builder.HasOne<OperationClaim>(a => a.OperationClaim).WithMany(a => a.UserAndOperationClaims).HasForeignKey(a => a.OperationClaimID);

            builder.ToTable("UserAndOperationClaims");
        }
    }
}
