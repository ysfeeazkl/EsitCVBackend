using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CompanyDtos
{
    public class CompanyDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string TaxNumber { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
