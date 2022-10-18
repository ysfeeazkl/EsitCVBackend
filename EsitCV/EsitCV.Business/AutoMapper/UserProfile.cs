using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AuthDtos;
using EsitCV.Entities.Dtos.UserDtos;
using EsitCV.Entities.Dtos.UserTokenDtos;
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
            CreateMap<UserLoginWithEmailDto, User>().ReverseMap();
            CreateMap<UserRegisterDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserTokenDto, UserToken>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
        }
    }
}
