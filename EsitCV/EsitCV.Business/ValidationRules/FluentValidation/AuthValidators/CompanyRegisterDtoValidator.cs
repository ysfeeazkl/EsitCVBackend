using EsitCV.Entities.Dtos.AuthDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.AuthValidators
{
    public class CompanyRegisterDtoValidator : AbstractValidator<CompanyRegisterDto>
    {
        public CompanyRegisterDtoValidator()
        {
            RuleFor(a => a.EmailAddress).Length(5, 80).WithMessage("Mail Adresi minimum 5 maksimum 80 karakter olmalıdır.");
            RuleFor(a => a.Name).Length(2, 50).WithMessage("İsim alanı minimum 2 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.Password).Length(8, 50).WithMessage("Şifre alanı minimum 8 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.PhoneNumber).MinimumLength(5).WithMessage("Telefon alanı minimum 5 karakter olmalıdır.");
            RuleFor(a => a.TaxNumber).Length(3, 15).WithMessage("Ta Adı alanı minimum 3 maksimum 50 karakter olmalıdır.");

            RuleFor(x => x.Password)
          .NotEmpty().WithMessage("Parola alanı boş bırakılamaz.")
          .Matches(@"[][""!@$%&*(){}:;,.?/+_=\\-]")
           .WithMessage("Parola özel bir karakter içermelidir");
        }
    }
}
