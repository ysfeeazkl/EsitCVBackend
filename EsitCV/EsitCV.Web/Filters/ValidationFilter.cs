using EsitCV.Business.Utilities;
using EsitCV.Shared.Entities.Concrete;
using EsitCV.Shared.Utilities.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EsitCV.API.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                List<Error> validationErrors = new List<Error>();
                foreach (var modelStateKey in context.ModelState.Keys)
                {
                    foreach (var error in context.ModelState[modelStateKey].Errors)
                    {
                        Error modelStateError = new Error
                        {
                            PropertyName = modelStateKey,
                            Message = error.ErrorMessage
                        };
                        validationErrors.Add(modelStateError);
                    }
                }
                throw new ValidationErrorsException(Messages.General.ValidationError(), validationErrors);
                //context.Result = new BadRequestObjectResult(new ApiResult
                //{
                //    Data = null,
                //    Message = $"Bir veya daha fazla validasyon hatası ile karşılaşıldı",
                //    Detail = $"Bir veya daha fazla validasyon hatası ile karşılaşıldı",
                //    ResultStatus = ResultStatus.Warning,
                //    StatusCode = HttpStatusCode.BadRequest,
                //    ValidationErrors = modelErrors,
                //    Href = context.HttpContext.Request.GetDisplayUrl()
                //});
            }
            await base.OnActionExecutionAsync(context, next);
        }
    }
}
