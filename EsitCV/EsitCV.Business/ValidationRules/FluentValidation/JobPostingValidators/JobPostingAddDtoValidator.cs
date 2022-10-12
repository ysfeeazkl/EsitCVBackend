using EsitCV.Entities.Dtos.JobPostingDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.JobPostingValidators
{

    public class JobPostingAddDtoValidator : AbstractValidator<JobPostingAddDto>
    {
        public JobPostingAddDtoValidator()
        {
            RuleFor(a => a.Header).NotNull().WithMessage("başlık alanı boş geçilmez");
            RuleFor(a => a.Content).NotNull().WithMessage("içerik alanı boş geçilmez");
            RuleFor(a => a.Sector).NotNull().WithMessage("sektör alanı boş geçilmez");
            RuleFor(a => a.JobPosition).NotNull().WithMessage("pozisyon alanı boş geçilmez");
            RuleFor(a => a.LicenceDegree).NotNull().WithMessage("Lisans derecesi alanı boş geçilmez");
            RuleFor(a => a.Language).NotNull().WithMessage("Dil alanı boş geçilmez");
            RuleFor(a => a.TypeOfWork).NotNull().WithMessage("Çalışma tipi boş geçilmez");
            RuleFor(a => a.CompanyID).GreaterThan(0).WithMessage("şirket alanı boş geçilmez");

        }
    }
  
}
