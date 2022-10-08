using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserLoginWithEmailDto, User>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}
