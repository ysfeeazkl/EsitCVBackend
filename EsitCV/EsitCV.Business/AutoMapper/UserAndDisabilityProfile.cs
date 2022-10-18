using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.UserDisabilityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{

    public class UserAndDisabilityProfile : Profile
    {
        public UserAndDisabilityProfile()
        {
            CreateMap<UserAndDisabilityAddDto, UserAndDisability>();
        }
    }

}
