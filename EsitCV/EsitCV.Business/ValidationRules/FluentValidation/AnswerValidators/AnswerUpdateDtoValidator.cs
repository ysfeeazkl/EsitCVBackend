﻿using EsitCV.Entities.Dtos.AnswerDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.AnswerValidators
{

    public class AnswerUpdateDtoValidator : AbstractValidator<AnswerUpdateDto>
    {
        public AnswerUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.Content).NotNull().WithMessage("içerik alanı boş geçilmez");
            RuleFor(a => a.QuestionID).GreaterThan(0).WithMessage("Soru alanı boş geçilmez");
        }
    }
}
