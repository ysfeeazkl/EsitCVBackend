using EsitCV.Entities.Dtos.CirriculumVitaeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.CirriculumVitaeValidators
{
  

    public class CirriculumVitaeUpdateDtoValidator : AbstractValidator<CirriculumVitaeUpdateDto>
    {
        public CirriculumVitaeUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.UserID).GreaterThan(0);
            RuleFor(a => a.File).NotNull().WithMessage("Dosya alanı dolu olmalıdır");
        }

    }
}
