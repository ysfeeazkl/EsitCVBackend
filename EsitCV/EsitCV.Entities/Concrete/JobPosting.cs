using EsitCV.Entities.ComplexTypes;
using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class JobPosting : EntityBase<int>, IEntity //buraya da iş ilanı için soru koleksiyonu gibi bişi yap
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Sector { get; set; }
        public string JobPosition { get; set; }
        public string LicenceDegree { get; set; }
        public string Language { get; set; }
        public TypeOfWork  TypeOfWork{ get; set; }


        public Company Company { get; set; }
        public int CompanyID { get; set; }

        public ICollection<Question> Questions{ get; set; }
        public ICollection<JobApplication> JobApplications{ get; set; }

        public JobPosting()
        {
            Questions=new List<Question>();
            JobApplications = new List<JobApplication>();
        }
    }
}
