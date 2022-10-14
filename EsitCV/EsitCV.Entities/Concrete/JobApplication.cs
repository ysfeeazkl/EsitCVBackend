using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class JobApplication : EntityBase<int>, IEntity // iş ilanı sorularına verilen cevaplar gibi bişi yapılcak
    {
        public User User { get; set; }
        public int UserID { get; set; }

        public CurriculumVitae CurriculumVitae { get; set; }
        public int CurriculumVitaeID { get; set; }
        public JobPosting JobPosting{ get; set; }
        public int JobPostingID{ get; set; }

        public ICollection<Answer>? Answers { get; set; }


    }
}
