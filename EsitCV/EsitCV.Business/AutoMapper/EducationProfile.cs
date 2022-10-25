using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.EducationDtos;

namespace EsitCV.Business.AutoMapper
{
 

    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<EducationAddDto, Education>();
            CreateMap<EducationUpdateDto, Education>();
        }
    }
}
