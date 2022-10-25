﻿using EsitCV.Entities.Dtos.FeaturesDtos.WorkExperienceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.FeaturesValidators.WorkExperienceValidators
{

    public class WorkExperienceUpdateDtoValidator : AbstractValidator<WorkExperienceUpdateDto>
    {
        public WorkExperienceUpdateDtoValidator()
        {

        }
    }
}
