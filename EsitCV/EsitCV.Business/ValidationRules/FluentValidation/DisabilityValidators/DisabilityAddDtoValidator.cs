using EsitCV.Entities.Dtos.DisabilityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.DisabilityValidators
{
    public class DisabilityAddDtoValidator : AbstractValidator<DisabilityAddDto>
    {
        public DisabilityAddDtoValidator()
        {
            RuleFor(a => a.Name).NotNull();

        }

    }
}
