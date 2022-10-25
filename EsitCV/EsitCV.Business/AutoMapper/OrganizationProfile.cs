using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos;

namespace EsitCV.Business.AutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<OrganizationAddDto, Organization>();
            CreateMap<OrganizationUpdateDto, Organization>();
        }
    }
}
