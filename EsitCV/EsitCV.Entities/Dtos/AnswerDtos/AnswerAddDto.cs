using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.AnswerDtos
{
    public class AnswerAddDto
    {
        public string Content { get; set; }
        public int QuestionID { get; set; }
        public int UserID { get; set; }
    }
}
