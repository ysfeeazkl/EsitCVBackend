using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CompanyTokenDtos
{
    public class CompanyTokenDto
    {
        public int Id { get; set; }
        public int CompanyID { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
        public DateTime CreatedDate { get; set; }
        public string IpAddress { get; set; }
    }
}
