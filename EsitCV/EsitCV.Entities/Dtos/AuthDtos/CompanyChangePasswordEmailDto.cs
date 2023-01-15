using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.AuthDtos
{
    public class CompanyChangePasswordEmailDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string ReTypePassword { get; set; }
    }
}
