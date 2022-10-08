using EsitCV.Entities.Dtos.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CompanyTokenDtos
{
    public class CompanyWithTokenDto
    {
        public CompanyDto Company { get; set; }
        public CompanyTokenDto Token { get; set; }
    }
}
