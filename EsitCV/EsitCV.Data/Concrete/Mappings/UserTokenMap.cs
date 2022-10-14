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
  

    public class UserTokenMap : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Token).IsRequired();
            builder.Property(a => a.TokenExpiration).IsRequired();
            builder.Property(a => a.UserID).IsRequired();

            builder.HasOne<User>(a => a.User).WithMany(a => a.UserTokens).HasForeignKey(a => a.UserID);
            builder.ToTable("UserTokens");
        }
    }
}
