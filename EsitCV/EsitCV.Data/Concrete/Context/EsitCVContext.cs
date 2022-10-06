using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Data.Concrete.Context
{
    public class EsitCVContext : DbContext
    {
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Data Source=94.199.202.242;Initial Catalog=apiesitc_esitcv_db;User Id=esitcv_db;Password=EsitCV22!Q;Trusted_Connection=false");
            optionsBuilder.UseSqlServer(@"Data Source=94.199.202.242;Initial Catalog=EsitCvDb;User Id=esitcv_db;Password=EsitCV22!Q;Trusted_Connection=false");
        }
    }
}
