using EsitCV.Entities.Dtos.FeaturesDtos.AboutDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.AreasOfInterestDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.AreasOfInterestValidators
{

    public class AreasOfInterestAddDtoValidator : AbstractValidator<AreasOfInterestAddDto>
    {
        public AreasOfInterestAddDtoValidator()
        {

        }
    }
}
