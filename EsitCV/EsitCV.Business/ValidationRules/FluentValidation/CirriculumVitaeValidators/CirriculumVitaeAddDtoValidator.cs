using EsitCV.Entities.Dtos.CirriculumVitaeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.CirriculumVitaeValidators
{
    public class CirriculumVitaeAddDtoValidator : AbstractValidator<CirriculumVitaeAddDto>
    {
        public CirriculumVitaeAddDtoValidator()
        {
            RuleFor(a => a.UserID).GreaterThan(0);
            RuleFor(a => a.File).NotNull().WithMessage("Dosya alanı dolu olmalıdır");
        }
       
    }
}
