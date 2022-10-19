using EsitCV.Entities.Dtos.LocationDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.ValidationRules.FluentValidation.LocationValidators
{
    public class LocationAddDtoValidator : AbstractValidator<LocationAddDto>
    {
        public LocationAddDtoValidator()
        {
            RuleFor(a => a.Province).NotNull().WithMessage("İl alanı boş geçilmez");
            RuleFor(a => a.District).NotNull().WithMessage("İlçe alanı boş geçilmez");
            RuleFor(a => a.Country).NotNull().WithMessage("Ülke alanı boş geçilmez");
            RuleFor(a => a.CompanyID).GreaterThan(0).WithMessage("Şirket alanı boş geçilmez");
          

        }
    }
}
