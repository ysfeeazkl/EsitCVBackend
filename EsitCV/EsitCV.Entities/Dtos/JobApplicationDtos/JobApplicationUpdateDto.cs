using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.JobApplicationDtos
{
    public class JobApplicationUpdateDto
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int CurriculumVitaeID { get; set; }
    }
}
