using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.AnswerDtos
{
    public class AnswerUpdateDto
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int QuestionID { get; set; }
    }
}
