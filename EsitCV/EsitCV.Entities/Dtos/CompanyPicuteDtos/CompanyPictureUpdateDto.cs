using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CompanyPicuteDtos
{
    public class CompanyPictureUpdateDto
    {
        public int CompanyID { get; set; }
        public IFormFile File { get; set; }
    }
}

