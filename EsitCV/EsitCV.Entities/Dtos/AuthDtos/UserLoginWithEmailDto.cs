using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.AuthDtos
{
    public class UserLoginWithEmailDto
    {
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
