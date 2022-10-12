using EsitCV.Entities.Dtos.CurriculumVitaeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.CurriculumVitaeValidators
{
  

    public class CurriculumVitaeUpdateDtoValidator : AbstractValidator<CurriculumVitaeUpdateDto>
    {
        public CurriculumVitaeUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.UserID).GreaterThan(0);
            RuleFor(a => a.File).NotNull().WithMessage("Dosya alanı dolu olmalıdır");
        }

    }
}
