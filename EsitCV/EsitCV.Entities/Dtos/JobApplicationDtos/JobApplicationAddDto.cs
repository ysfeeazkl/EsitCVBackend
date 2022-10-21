using EsitCV.Entities.Dtos.AnswerDtos;
using EsitCV.Entities.Dtos.QuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Entities.Dtos.JobApplicationDtos
{
    public class JobApplicationAddDto
    {
        public int UserID { get; set; }
        //public int CurriculumVitaeID { get; set; }
        public int JobPostingID { get; set; }
        public List<JobApplicationAnswerAddDto>? Answers { get; set; }
    } 
}
