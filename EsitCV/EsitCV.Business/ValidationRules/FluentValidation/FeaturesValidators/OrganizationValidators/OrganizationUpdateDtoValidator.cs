using EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.OrganizationValidators
{

    public class OrganizationUpdateDtoValidator : AbstractValidator<OrganizationUpdateDto>
    {
        public OrganizationUpdateDtoValidator()
        {

        }
    }
}
