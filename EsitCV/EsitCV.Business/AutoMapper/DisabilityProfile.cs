using AutoMapper;
using EsitCV.Entities.Concrete.Disableds;
using EsitCV.Entities.Dtos.DisabilityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class DisabilityProfile : Profile
    {
        public DisabilityProfile()
        {
            CreateMap<DisabilityAddDto, Disability>();
        }
    }
}
