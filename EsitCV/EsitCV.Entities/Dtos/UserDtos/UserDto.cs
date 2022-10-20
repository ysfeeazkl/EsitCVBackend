using EsitCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.UserDtos
{
    public class UserDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public DateTime LastLogin { get; set; }

        public UserPicture UserPicture { get; set; }
        public int UserPictureID { get; set; }

        public UserProfile UserProfile { get; set; }
        public int UserProfileID { get; set; }

        public CurriculumVitae CurriculumVitae { get; set; }
        public int CurriculumVitaeID { get; set; }

        //public ICollection<JobApplication> JobApplications { get; set; }
        //public ICollection<UserAndOperationClaim> UserAndOperationClaims { get; set; }
        //public ICollection<UserToken> UserTokens { get; set; }
        //public ICollection<UserAndDisability> UserAndDisabilities { get; set; }

        //[NotMapped]
        //public ICollection<IFeatures> Features { get; set; }
    }
}
