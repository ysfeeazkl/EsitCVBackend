using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.EducationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.EducationValidators
{

    public class EducationAddDtoValidator : AbstractValidator<EducationAddDto>
    {
        public EducationAddDtoValidator()
        {
            RuleFor(a => a.InstitutionName).NotNull();
            RuleFor(a => a.Activity).NotNull();
            RuleFor(a => a.Degree).NotNull();
            RuleFor(a => a.Content).NotNull();
            RuleFor(a => a.EducationCategory).NotNull();
            RuleFor(a => a.StartDate).NotNull();
            RuleFor(a => a.FinishDate).NotNull();

        }
    }
}
