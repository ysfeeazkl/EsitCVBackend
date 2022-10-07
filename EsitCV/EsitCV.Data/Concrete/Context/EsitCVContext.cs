using EsitCV.Entities.Concrete;
using EsitCV.Entities.Concrete.Disableds;
using EsitCV.Entities.Concrete.Features;
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
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AreasOfInterest> AreasOfInterests { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CurrentProject> CurrentProjects { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Hobbie> Hobbies { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LicenseOrCertificate> LicenseOrCertificates { get; set; }
        public DbSet<Organization> Organizations { get; set; }      
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPicture> CompanyPictures { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitaes { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<JobApplicationAndJobPosting> JobApplicationAndJobPostings { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAndOperationClaim> UserAndOperationClaims { get; set; }
        public DbSet<UserDisability> UserDisabilitys { get; set; }
        public DbSet<UserPicture> UserPictures { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(@"Data Source=94.199.202.242;Initial Catalog=apiesitc_esitcv_db;User Id=esitcv_db;Password=EsitCV22!Q;Trusted_Connection=false");
            //optionsBuilder.UseSqlServer(@"Data Source=94.199.202.242;Initial Catalog=EsitCvDb;User Id=esitcv_db;Password=EsitCV22!Q;Trusted_Connection=false");
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=EsitCvDb;Trusted_Connection=True;");
        }
    }
}
