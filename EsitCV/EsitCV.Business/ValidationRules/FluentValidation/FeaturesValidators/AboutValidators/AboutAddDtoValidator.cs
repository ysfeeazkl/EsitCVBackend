using EsitCV.Entities.Dtos.DisabilityDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AboutValidators
{
  
    public class AboutAddDtoValidator : AbstractValidator<AboutAddDto>
    {
        public AboutAddDtoValidator()
        {
            RuleFor(a => a.Content).NotNull();
        }
    }
}
