using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.LicenseOrCertificateValidators
{
 

    public class LicenseOrCertificateUpdateDtoValidator : AbstractValidator<LicenseOrCertificateUpdateDto>
    {
        public LicenseOrCertificateUpdateDtoValidator()
        {

        }
    }
}
