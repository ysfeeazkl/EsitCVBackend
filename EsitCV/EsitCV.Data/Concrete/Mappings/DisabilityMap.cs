using EsitCV.Entities.Concrete.Disableds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Data.Concrete.Mappings
{
    public class DisabilityMap : IEntityTypeConfiguration<Disability>
    {
        public void Configure(EntityTypeBuilder<Disability> builder)
        {
            builder.HasKey(a => a.ID);
            builder.Property(a => a.ID).ValueGeneratedOnAdd();
            builder.ToTable("Disabilities");

            builder.HasData(new Disability()
            {
                ID = 1,
                Name = "İşitme",
                CreatedDate = DateTime.Now,
            },
            new Disability()
            {
                ID = 2,
                Name = "Bedensel",
                CreatedDate = DateTime.Now,
            },
            new Disability()
            {
                ID = 3,
                Name = "Görme",
                CreatedDate = DateTime.Now,
            },
            new Disability()
            {
                ID = 4,
                Name = "Süreğen Hastalık (Kronik)",
                CreatedDate = DateTime.Now,
            },
            new Disability()
            {
                ID = 5,
                Name = "Dil ve Konuşma Bozuklupu",
                CreatedDate = DateTime.Now,
            },
            new Disability()
            {
                ID = 6,
                Name = "Zihinsel (MR)",
                CreatedDate = DateTime.Now,
            },
            new Disability()
            {
                ID = 7,
                Name = "Sınıflanamayan",
                CreatedDate = DateTime.Now,
            }
            );

            builder.ToTable("Disabilities");
        }
    }
}
