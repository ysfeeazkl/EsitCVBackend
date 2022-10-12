using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CirriculumVitaeDtos
{
    public class CirriculumVitaeUpdateDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public IFormFile File { get; set; }
    }
}
