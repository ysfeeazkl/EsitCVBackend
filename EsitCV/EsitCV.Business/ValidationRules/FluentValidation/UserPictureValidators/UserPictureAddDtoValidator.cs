using EsitCV.Entities.Dtos.UserPictureDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.UserPictureValidators
{
  
    public class UserPictureAddDtoValidator : AbstractValidator<UserPictureAddDto>
    {
        public UserPictureAddDtoValidator()
        {
            RuleFor(a => a.UserID).GreaterThan(0);
            RuleFor(a => a.File).NotNull().WithMessage("Dosya alanı dolu olmalıdır");
        }

    }
}
