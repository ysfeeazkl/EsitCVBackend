using EsitCV.Entities.Dtos.FeaturesDtos.LicenseOrCertificateDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.OrganizationValidators
{


    public class OrganizationAddDtoValidator : AbstractValidator<OrganizationAddDto>
    {
        public OrganizationAddDtoValidator()
        {

            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.StartDate).NotNull();
            RuleFor(a => a.Content).NotNull();
            RuleFor(a => a.IssuingBodyName).NotNull();

        }
    }
}
