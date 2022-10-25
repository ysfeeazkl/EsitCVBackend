using AutoMapper;
using EsitCV.Data.Concrete.Mappings;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{

    public class AreasOfInterestProfile : Profile
    {
        public AreasOfInterestProfile()
        {
            CreateMap<AreasOfInterestAddDto, AreasOfInterest>();
            CreateMap<AreasOfInterestUpdateDto, AreasOfInterest>();
        }
    }
}
