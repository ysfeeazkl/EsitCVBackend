using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.UserPictureDtos;

namespace EsitCV.Business.AutoMapper
{

    public class UserPictureProfile : Profile
    {
        public UserPictureProfile()
        {
            CreateMap<UserPictureAddDto, UserPicture>();
            CreateMap<UserPictureUpdateDto, UserPicture>();
        }
    }
}
