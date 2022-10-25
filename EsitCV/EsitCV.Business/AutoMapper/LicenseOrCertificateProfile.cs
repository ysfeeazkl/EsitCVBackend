using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using EsitCV.Entities.Concrete.Features;
using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;

namespace EsitCV.Business.AutoMapper
{

    public class LicenseOrCertificateProfile : Profile
    {
        public LicenseOrCertificateProfile()
        {
            CreateMap<LicenseOrCertificateAddDto, LicenseOrCertificate>();
            CreateMap<LicenseOrCertificateUpdateDto, LicenseOrCertificate>();
        }
    }
}
