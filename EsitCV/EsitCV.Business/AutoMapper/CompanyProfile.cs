using AutoMapper;
using EsitCV.Entities.Concrete;
using EsitCV.Entities.Dtos.AuthDtos;
using EsitCV.Entities.Dtos.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyLoginWithEmailDto, Company>();
            CreateMap<CompanyRegisterDto, Company>();
            CreateMap<CompanyDto, Company>();
        }
    }
}
