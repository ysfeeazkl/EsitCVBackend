using EsitCV.Entities.Dtos.FeaturesDtos.LanguageDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.LicenseOrCertificateValidators
{
    public class LicenseOrCertificateAddDtoValidator : AbstractValidator<LicenseOrCertificateAddDto>
    {
        public LicenseOrCertificateAddDtoValidator()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.ReceivedDate).NotNull();
            RuleFor(a => a.Content).NotNull();
            RuleFor(a => a.IssuingBodyName).NotNull();

        }
    }
}
