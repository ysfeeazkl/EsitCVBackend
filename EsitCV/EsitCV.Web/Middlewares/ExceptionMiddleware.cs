using EsitCV.Shared.Entities.ComplexTypes;
using EsitCV.Shared.Utilities.Exceptions;
using EsitCV.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Http.Extensions;
using Serilog;
using System.Text.Json;

namespace EsitCV.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Unhandled exception");
                switch (ex)
                {
                    case NotFoundArgumentException error1:
                        await NotFoundArgumentException(context, error1);
                        break;
                    case NotFoundArgumentsException error2:
                        await NotFoundArgumentsException(context, error2);
                        break;
                    case ValidationErrorsException error3:
                        await ValidationErrorAsync(context, error3);
                        break;
                    default:
                        await GeneralException(context, ex);
                        break;
                }
            }
            finally
            {
                Log.Information("Başarılı istek adresi: " + context.Request.GetDisplayUrl());
                Log.CloseAndFlush();
            }
        }
        private async Task GeneralException(HttpContext context, Exception exception)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Error,
                Message = exception.Message,
                Detail = exception.StackTrace,
                StatusCode = HttpStatusCode.InternalServerError,
                Href = context.Request.GetDisplayUrl()
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;
            _logger.LogError(exception.Message);

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        private async Task NotFoundArgumentException(HttpContext context, NotFoundArgumentException exception)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Warning,
                Message = exception.Message,
                Error = exception.ValidationError,
                StatusCode = HttpStatusCode.BadRequest,
                Href = context.Request.GetDisplayUrl()
            };
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            _logger.LogError(exception.Message);

            await context.Response.WriteAsync(result);
        }
        private async Task NotFoundArgumentsException(HttpContext context, NotFoundArgumentsException exception)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Warning,
                Message = exception.Message,
                Error = exception.ValidationErrors,
                StatusCode = HttpStatusCode.BadRequest,
                Href = context.Request.GetDisplayUrl()
            };
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            _logger.LogError(exception.Message);

            await context.Response.WriteAsync(result);
        }
        private async Task ValidationErrorAsync(HttpContext context, ValidationErrorsException exception)
        {
            var problemDetails = new
            {
                ResultStatus = ResultStatus.Warning,
                Message = exception.Message,
                Error = exception.ValidationErrors,
                StatusCode = HttpStatusCode.BadRequest,
                Href = context.Request.GetDisplayUrl()
            };
            var result = JsonSerializer.Serialize(problemDetails);
            context.Response.ContentType = "application/json";
            _logger.LogError(exception.Message);

            await context.Response.WriteAsync(result);
        }
    }
}

