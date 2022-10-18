using EsitCV.Entities.Dtos.CompanyPicuteDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.CompanyPicuteValidators
{
    public class CompanyPictureUpdateDtoValidator : AbstractValidator<CompanyPictureUpdateDto>
    {
        public CompanyPictureUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.CompanyID).GreaterThan(0);
            RuleFor(a => a.File).NotNull().WithMessage("Dosya alanı dolu olmalıdır");
        }

    }
}
