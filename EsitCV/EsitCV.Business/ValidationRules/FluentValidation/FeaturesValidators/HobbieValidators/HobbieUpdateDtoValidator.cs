using EsitCV.Entities.Dtos.FeaturesDtos.HobbieDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.HobbieValidators
{
    public class HobbieUpdateDtoValidator : AbstractValidator<HobbieUpdateDto>
    {
        public HobbieUpdateDtoValidator()
        {

        }
    }
}
