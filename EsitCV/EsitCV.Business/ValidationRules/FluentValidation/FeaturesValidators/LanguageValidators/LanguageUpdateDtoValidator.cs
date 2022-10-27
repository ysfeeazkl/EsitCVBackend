using EsitCV.Entities.Dtos.FeaturesDtos.LanguageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.LanguageValidators
{
 
    public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
    {
        public LanguageUpdateDtoValidator()
        {
            RuleFor(a => a.ID).NotNull();
            RuleFor(a => a.Level).NotNull();
            RuleFor(a => a.Name).NotNull();

        }
    }
}
