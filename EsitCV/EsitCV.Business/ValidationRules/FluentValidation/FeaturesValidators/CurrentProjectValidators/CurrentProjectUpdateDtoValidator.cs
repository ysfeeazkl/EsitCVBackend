using EsitCV.Entities.Dtos.FeaturesDtos.CurrentProjectDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CurrentProjectValidators
{
 
    public class CurrentProjectUpdateDtoValidator : AbstractValidator<CurrentProjectUpdateDto>
    {
        public CurrentProjectUpdateDtoValidator()
        {

        }
    }
}
