using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.UserProfileDtos;

namespace EsitCV.Business.AutoMapper
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            CreateMap<UserProfileAddDto, UserProfile>();
            CreateMap<UserProfileUpdateDto, UserProfile>();
        }
    }
}
