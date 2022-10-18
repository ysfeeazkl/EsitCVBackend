using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.CompanyPicuteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class CompanyPictureProfile : Profile
    {
        public CompanyPictureProfile()
        {
            CreateMap<CompanyPictureAddDto, CompanyPicture>();
            CreateMap<CompanyPictureUpdateDto, CompanyPicture>();
        }
    }
}
