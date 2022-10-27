﻿using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;
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
            RuleFor(a => a.ID).NotNull();
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.ReceivedDate).NotNull();
            RuleFor(a => a.Content).NotNull();
            RuleFor(a => a.IssuingBodyName).NotNull();
        }
    }
}
