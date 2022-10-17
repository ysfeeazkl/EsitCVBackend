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
    public class CurriculumVitaeMap : IEntityTypeConfiguration<CurriculumVitae>
    {
        public void Configure(EntityTypeBuilder<CurriculumVitae> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.FileUrl).IsRequired();
            builder.Property(u => u.FileName).IsRequired();
       
            builder.ToTable("CurriculumVitaes");
        }
    }
}
