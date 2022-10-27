using EsitCV.Entities.Dtos.FeaturesDtos.CourseDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.CourseValidators
{

    public class CourseUpdateDtoValidator : AbstractValidator<CourseUpdateDto>
    {
        public CourseUpdateDtoValidator()
        {
            RuleFor(a => a.ID).NotNull();
            RuleFor(a => a.Name).NotNull();
            RuleFor(a => a.ReceivedDate).NotNull();
            RuleFor(a => a.Content).NotNull();
        }
    }
}
