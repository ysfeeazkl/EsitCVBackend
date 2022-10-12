using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.CurriculumVitaeDtos
{
    public class CurriculumVitaeAddDto
    {
      
        public int UserID { get; set; }
        public IFormFile File { get; set; }
    }
}
