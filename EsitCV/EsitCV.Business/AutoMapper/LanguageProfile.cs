using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.LanguageDtos;

namespace EsitCV.Business.AutoMapper
{

    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<LanguageAddDto, Language>();
            CreateMap<LanguageUpdateDto, Language>();
        }
    }
}
