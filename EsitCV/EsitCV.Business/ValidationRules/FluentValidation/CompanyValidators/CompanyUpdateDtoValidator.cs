﻿using EsitCV.Entities.Dtos.CompanyDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.CompanyValidators
{
    public class CompanyUpdateDtoValidator : AbstractValidator<CompanyUpdateDto>
    {
        public CompanyUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.EmailAddress).Length(5, 80).WithMessage("Mail Adresi minimum 5 maksimum 80 karakter olmalıdır.");
            RuleFor(a => a.Name).Length(2, 50).WithMessage("İsim alanı minimum 2 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.PhoneNumber).MinimumLength(5).WithMessage("Telefon alanı minimum 5 karakter olmalıdır.");
            RuleFor(a => a.TaxNumber).Length(10).WithMessage("Tax Adı alanı minimum 3 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.Sector).Length(3, 20).WithMessage("Sektör Adı alanı minimum 3 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.YearOfFoundation).NotNull();

    }
}
}
