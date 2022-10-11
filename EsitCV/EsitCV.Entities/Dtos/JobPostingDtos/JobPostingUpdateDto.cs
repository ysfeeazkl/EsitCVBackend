using EsitCV.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.JobPostingDtos
{
    public class JobPostingUpdateDto
    {
        public int ID { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Sector { get; set; }
        public string JobPosition { get; set; }
        public string LicenceDegree { get; set; }
        public string Language { get; set; }
        public TypeOfWork TypeOfWork { get; set; }
        public int CompanyID { get; set; }
    }
}
