using EsitCV.Shared.Entities.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Concrete
{
    public class Answer: EntityBase<int>, IEntity
    {
        public string Content { get; set; }
        public Question Question { get; set; }
        public int QuestionID { get; set; }
    }
}
