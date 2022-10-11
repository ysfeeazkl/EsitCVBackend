using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.JobApplicationAndJobPostingDtos
{
    public class JobApplicationAndJobPostingUpdateDto
    {
        public int JobApplicationID { get; set; }
        public int JobPostingID { get; set; }
        public int? NewJobApplicationID { get; set; }
        public int? NewJobPostingID { get; set; }
    }
}
