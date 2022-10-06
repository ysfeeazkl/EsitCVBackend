using AutoMapper;
using EsitCV.Shared.Entities.Concrete;
using EsitCV.Shared.Utilities.Exceptions;
using FluentValidation;

namespace EsitCV.Shared.Utilities.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                IList<Error> validationErrors = new List<Error>();
                foreach (var error in result.Errors)
                {
                    validationErrors.Add(new Error
                    {
                        PropertyName = error.PropertyName,
                        Message = error.ErrorMessage
                    });
                }
                throw new ValidationErrorsException("Bir veya daha fazla validasyon hatasına rastlandı.", validationErrors);
            }
        }
    }
}
