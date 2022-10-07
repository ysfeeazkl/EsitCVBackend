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
        public ICollection<AreasOfInterest> AreasOfInterest { get; set; }
        public ICollection<Course>  Courses { get; set; }
        public ICollection<Education> Education { get; set; }
        public ICollection<Hobbies> Hobbies { get; set; }
        public ICollection<Language> Language { get; set; }
        public ICollection<LicenseOrCertificate> LicenseOrCertificate { get; set; }
        public ICollection<Project> Project { get; set; }
        public ICollection<WorkExperience> WorkExperience { get; set; }


        public User User{ get; set; }
        public int UserID{ get; set; }
    }
}
