using AutoMapper;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{

    public class CurrentProjectProfile : Profile
    {
        public CurrentProjectProfile()
        {
            CreateMap<CurrentProjectAddDto, CurrentProject>();
            CreateMap<CurrentProjectUpdateDto, CurrentProject>();
        }
    }
}
