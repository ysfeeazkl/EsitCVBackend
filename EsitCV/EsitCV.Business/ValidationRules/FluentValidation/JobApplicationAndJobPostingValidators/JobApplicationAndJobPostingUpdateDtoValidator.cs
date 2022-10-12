using EsitCV.Entities.Dtos.JobApplicationAndJobPostingDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.JobApplicationAndJobPostingValidators
{
    public class JobApplicationAndJobPostingUpdateDtoValidator : AbstractValidator<JobApplicationAndJobPostingUpdateDto>
    {
        public JobApplicationAndJobPostingUpdateDtoValidator()
        {
            RuleFor(a => a.JobApplicationID).GreaterThan(0).WithMessage("İş başvuru alanı boş geçilmez");
            RuleFor(a => a.JobPostingID).GreaterThan(0).WithMessage("İş ilanı alanı boş geçilmez");

            RuleFor(a => a.NewJobApplicationID).GreaterThan(0).When(a => a.NewJobApplicationID < 1); 
            RuleFor(a => a.NewJobPostingID).GreaterThan(0).When(a => a.NewJobPostingID < 1);

        }
    }
}
