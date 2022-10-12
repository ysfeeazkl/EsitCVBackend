using EsitCV.Entities.Dtos.JobApplicationAndJobPostingDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.JobApplicationAndJobPostingValidators
{
    public class JobApplicationAndJobPostingAddDtoValidator : AbstractValidator<JobApplicationAndJobPostingAddDto>
    {
        public JobApplicationAndJobPostingAddDtoValidator()
        {
            RuleFor(a => a.JobApplicationID).GreaterThan(0).WithMessage("İş başvuru alanı boş geçilmez");
            RuleFor(a => a.JobPostingID).GreaterThan(0).WithMessage("İş ilanı alanı boş geçilmez");

        }
    }
}
