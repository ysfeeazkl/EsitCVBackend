using EsitCV.Entities.Abstract.Features;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class User : EntityBase<int>, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string? IpAddress { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime LastLogin { get; set; }

        //     

        public UserDisability UserDisability { get; set; }
        public int UserDisabilityID { get; set; }

        public int UserPictureID { get; set; }
        public UserPicture UserPicture { get; set; }

        public UserProfile UserProfile { get; set; }
        public int UserProfileID { get; set; }

        public ICollection<JobApplicationAndJobPosting> JobApplicationAndJobPostings { get; set; }
        public ICollection<UserAndOperationClaim> UserAndOperationClaims { get; set; }
        public ICollection<IFeatures> Features { get; set; }

    }
}
