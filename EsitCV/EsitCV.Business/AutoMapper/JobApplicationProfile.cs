using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.JobApplicationDtos;

namespace EsitCV.Business.AutoMapper
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile()
        {
            CreateMap<JobApplicationAddDto, JobApplication>();
            CreateMap<JobApplicationUpdateDto, JobApplication>();
        }
    }
}
