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

        public Company Company { get; set; }
        public int CompanyID { get; set; }

        public ICollection<JobApplicationAndJobPosting> JobApplicationAndJobPostings { get; set; }
        public ICollection<Question> Questions{ get; set; }

    }
}
