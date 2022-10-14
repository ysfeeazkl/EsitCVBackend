using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class Question: EntityBase<int>, IEntity
    {
        public string Content { get; set; }
        public JobPosting JobPosting { get; set; }
        public int JobPostingID { get; set; }

        public ICollection<Answer> Answers { get; set; }

    }
}
