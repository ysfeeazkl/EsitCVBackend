using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CurrentProjectValidators
{
    public class CurrentProjectAddDtoValidator : AbstractValidator<CurrentProjectAddDto>
    {
        public CurrentProjectAddDtoValidator()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.ProjectUrl).NotNull();
            RuleFor(a => a.Content).NotNull();
        }
    }
}
