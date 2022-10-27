using EsitCV.Entities.Dtos.FeaturesDtos.OrganizationDtos;
using EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.WorkExperienceValidators
{


    public class WorkExperienceAddDtoValidator : AbstractValidator<WorkExperienceAddDto>
    {
        public WorkExperienceAddDtoValidator()
        {
            RuleFor(a => a.CompanyName).NotNull();
            RuleFor(a => a.CompanyID).NotNull();
            RuleFor(a => a.Content).NotNull();
            RuleFor(a => a.Title).NotNull();
            RuleFor(a => a.Activity).NotNull();
            RuleFor(a => a.Degree).NotNull();
            RuleFor(a => a.EducationCategory).NotNull();
            RuleFor(a => a.StartDate).NotNull();
        }
    }
}
