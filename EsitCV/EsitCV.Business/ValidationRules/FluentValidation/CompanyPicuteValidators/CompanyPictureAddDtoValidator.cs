using EsitCV.Entities.Dtos.CompanyPicuteDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.CompanyPicuteValidators
{
    public class CompanyPictureAddDtoValidator : AbstractValidator<CompanyPictureAddDto>
    {
        public CompanyPictureAddDtoValidator()
        {
            RuleFor(a => a.CompanyID).GreaterThan(0);
            RuleFor(a => a.File).NotNull().WithMessage("Dosya alanı dolu olmalıdır");
        }

    }
}
