using EsitCV.Entities.Dtos.AnswerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.AnswerValidators
{
    public class AnswerAddDtoValidator : AbstractValidator<AnswerAddDto>
    {
        public AnswerAddDtoValidator()
        {
            RuleFor(a => a.Content).NotNull().WithMessage("içerik alanı boş geçilmez");
            RuleFor(a => a.QuestionID).GreaterThan(0).WithMessage("Soru alanı boş geçilmez");
            RuleFor(a => a.UserID).GreaterThan(0).WithMessage("Kullancı alanı boş geçilmez");
        }
    }
}
