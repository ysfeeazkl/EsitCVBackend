using EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos;
using EsitCV.Entities.Dtos.UserProfileDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.UserProfileValidators
{


    public class UserProfileAddDtoValidator : AbstractValidator<UserProfileAddDto>
    {
        public UserProfileAddDtoValidator()
        {
            RuleFor(a => a.UserID);
        }
    }
}
