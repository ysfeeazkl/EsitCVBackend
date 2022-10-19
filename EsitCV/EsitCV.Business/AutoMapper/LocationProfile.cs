using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.LocationDtos;

namespace EsitCV.Business.AutoMapper
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<LocationAddDto, Location>();
            CreateMap<LocationUpdateDto, Location>();
        }
    }
}
