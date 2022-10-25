using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.HobbieDtos;

namespace EsitCV.Business.AutoMapper
{

    public class HobbieProfile : Profile
    {
        public HobbieProfile()
        {
            CreateMap<HobbieAddDto, Hobbie>();
            CreateMap<HobbieUpdateDto, Hobbie>();
        }
    }
}
