using AutoMapper;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseAddDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
        }
    }
}
