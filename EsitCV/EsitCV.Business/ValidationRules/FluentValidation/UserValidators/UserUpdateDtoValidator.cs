using EsitCV.Entities.Dtos.UserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.UserValidators
{

    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            RuleFor(a => a.ID).GreaterThan(0);
            RuleFor(a => a.EmailAddress).Length(5, 80).WithMessage("Mail Adresi minimum 5 maksimum 80 karakter olmalıdır.");
            RuleFor(a => a.FirstName).Length(2, 50).WithMessage("İsim alanı minimum 2 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.LastName).Length(2, 50).WithMessage("İsim alanı minimum 2 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.PhoneNumber).MinimumLength(5).WithMessage("Telefon alanı minimum 5 karakter olmalıdır.");
            RuleFor(a => a.UserName).Length(3, 15).WithMessage("kullanıcı adı alanı minimum 3 maksimum 50 karakter olmalıdır.");
            RuleFor(a => a.Birthday).NotNull();

         
        }
    }
}
