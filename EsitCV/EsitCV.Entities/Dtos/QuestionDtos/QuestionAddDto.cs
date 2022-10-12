using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.QuestionDtos
{
    public class QuestionAddDto
    {
        public string Content { get; set; }
        public int JobPostingID { get; set; }
    }
}
