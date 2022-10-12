using EsitCV.Entities.Dtos.JobApplicationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.JobApplicationValidators
{
   

    public class JobApplicationUpdateDtoValidator : AbstractValidator<JobApplicationUpdateDto>
    {
        public JobApplicationUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.UserID).GreaterThan(0).WithMessage("kullanıcı alanı boş geçilmez");
            RuleFor(a => a.CurriculumVitaeID).GreaterThan(0).WithMessage("cv alanı boş geçilmez");

        }
    }
}
