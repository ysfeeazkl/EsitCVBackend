using EsitCV.Entities.Concrete.Features;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class UserProfile:EntityBase<int>,IEntity
    {
        public About About { get; set; }
        public int AboutID { get; set; }
        public ICollection<AreasOfInterest> AreasOfInterests { get; set; }
        public ICollection<Course>  Courses { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Hobbie> Hobbies { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<LicenseOrCertificate> LicenseOrCertificates { get; set; }
        public ICollection<CurrentProject> CurrentProjects { get; set; }
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        public ICollection<Organization> Organizations { get; set; }
        public User User{ get; set; }
        public int UserID{ get; set; }
    }
}
