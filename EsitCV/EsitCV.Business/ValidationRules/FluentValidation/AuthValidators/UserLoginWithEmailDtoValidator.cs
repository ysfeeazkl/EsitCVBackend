using EsitCV.Entities.Dtos.AuthDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.AuthValidators
{
    public class UserLoginWithEmailDtoValidator:AbstractValidator<UserLoginWithEmailDto>
    {
        public UserLoginWithEmailDtoValidator()
        {
            RuleFor(a => a.EmailAddress).NotEmpty().WithMessage("Mail adresi zorunludur.");
            RuleFor(a => a.EmailAddress).Length(5, 80).WithMessage("Mail adresi minimum 5 maksimum 80 karakter olmalıdır.");
            RuleFor(a => a.Password).NotEmpty().WithMessage("Parola alanı boş geçilmez");
            RuleFor(a => a.Password).Length(8, 80).WithMessage("Şifre minimum 8 maksimum 80 karakter olmalıdır.");
        }
    }
}
