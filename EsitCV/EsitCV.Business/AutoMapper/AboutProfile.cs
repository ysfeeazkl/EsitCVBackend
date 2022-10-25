using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.AnswerDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
  
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<AboutAddDto, About>();
            CreateMap<AboutUpdateDto, About>();
        }
    }
}
