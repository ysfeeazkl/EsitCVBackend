using EsitCV.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.UserDtos
{
    public class UserGetDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string? IpAddress { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime LastLogin { get; set; }
        public UserPicture UserPicture { get; set; }
        public int UserPictureID { get; set; }
        public UserProfile UserProfile { get; set; }
        public int UserProfileID { get; set; }
        public CurriculumVitae CurriculumVitae { get; set; }
        public int CurriculumVitaeID { get; set; }

    }
}
