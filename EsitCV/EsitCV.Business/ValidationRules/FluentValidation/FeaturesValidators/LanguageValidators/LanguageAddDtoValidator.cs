using EsitCV.Entities.Dtos.FeaturesDtos.HobbieDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.LanguageDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.LanguageValidators
{

    public class LanguageAddDtoValidator : AbstractValidator<LanguageAddDto>
    {
        public LanguageAddDtoValidator()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.Level).NotNull();

        }
    }
}
