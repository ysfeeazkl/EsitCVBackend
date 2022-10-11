using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.JobApplicationAndJobPostingDtos;

namespace EsitCV.Business.AutoMapper
{
    public class JobApplicationAndJobPostingProfile : Profile
    {
        public JobApplicationAndJobPostingProfile()
        {
            CreateMap<JobApplicationAndJobPostingAddDto, JobApplicationAndJobPosting>();
            CreateMap<JobApplicationAndJobPostingUpdateDto, JobApplicationAndJobPosting>();
        }
    }
}
