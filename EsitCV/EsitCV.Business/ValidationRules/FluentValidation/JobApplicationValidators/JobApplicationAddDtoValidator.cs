using EsitCV.Entities.Dtos.JobApplicationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.JobApplicationValidators
{

    public class JobApplicationAddDtoValidator : AbstractValidator<JobApplicationAddDto>
    {
        public JobApplicationAddDtoValidator()
        {
            RuleFor(a => a.UserID).GreaterThan(0).WithMessage("kullanıcı alanı boş geçilmez");
            RuleFor(a => a.CurriculumVitaeID).GreaterThan(0).WithMessage("cv alanı boş geçilmez");
            RuleFor(a => a.JobPostingID).GreaterThan(0).WithMessage("iş ilanı alanı boş geçilmez");

        }
    }
}
