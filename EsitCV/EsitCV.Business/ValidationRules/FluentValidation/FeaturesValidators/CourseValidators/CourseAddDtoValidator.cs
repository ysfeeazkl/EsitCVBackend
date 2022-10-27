using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators
{

    public class CourseAddDtoValidator : AbstractValidator<CourseAddDto>
    {
        public CourseAddDtoValidator()
        {
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.ReceivedDate).NotNull();
            RuleFor(a => a.Content).NotNull();

        }
    }
}
