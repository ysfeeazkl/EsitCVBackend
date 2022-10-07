using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.AuthDtos
{
    public class CompanyLoginWithEmailDto
    {
        public string Password { get; set; }
        public string EmailAddress { get; set; }
    }
}
