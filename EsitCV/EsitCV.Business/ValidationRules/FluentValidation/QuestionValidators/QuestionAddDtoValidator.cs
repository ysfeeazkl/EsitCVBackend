using EsitCV.Entities.Dtos.QuestionDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.QuestionValidators
{
    public class QuestionAddDtoValidator : AbstractValidator<QuestionAddDto>
    {
        public QuestionAddDtoValidator()
        {
            RuleFor(a => a.Content).NotNull().WithMessage("içerik alanı boş geçilmez");
            RuleFor(a => a.JobPostingID).NotNull().WithMessage("başlık alanı boş geçilmez");
        }
    }
}
