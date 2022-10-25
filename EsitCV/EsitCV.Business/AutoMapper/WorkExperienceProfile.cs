using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos;

namespace EsitCV.Business.AutoMapper
{
    public class WorkExperienceProfile : Profile
    {
        public WorkExperienceProfile()
        {
            CreateMap<WorkExperienceAddDto, WorkExperience>();
            CreateMap<WorkExperienceUpdateDto, WorkExperience>();
        }
    }
}
