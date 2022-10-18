using EsitCV.Entities.Dtos.UserDisabilityDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.UserAndDisabilityValidators
{
    public class UserAndDisabilityAddDtoValidator : AbstractValidator<UserAndDisabilityAddDto>
    {
        public UserAndDisabilityAddDtoValidator()
        {
            RuleFor(a => a.UserID).NotNull().GreaterThan(0);
            RuleFor(a => a.DisabilityID).NotNull().GreaterThan(0);
            RuleFor(a => a.PercentageOfDisability).NotNull().GreaterThan(0);
        }
    }
}
