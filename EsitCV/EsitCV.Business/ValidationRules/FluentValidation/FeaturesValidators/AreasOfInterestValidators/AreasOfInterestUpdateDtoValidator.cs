using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AreasOfInterestValidators
{


    public class AreasOfInterestUpdateDtoValidator : AbstractValidator<AreasOfInterestUpdateDto>
    {
        public AreasOfInterestUpdateDtoValidator()
        {
            RuleFor(a => a.ID).NotNull();
            RuleFor(a => a.Name).NotNull();

        }
    }
}
