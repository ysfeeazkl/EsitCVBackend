using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.JobPostingDtos;

namespace EsitCV.Business.AutoMapper
{
    public class JobPostingProfile : Profile
    {
        public JobPostingProfile()
        {
            CreateMap<JobPostingAddDto, JobPosting>();
            CreateMap<JobPostingUpdateDto, JobPosting>();
        }
    }
}
