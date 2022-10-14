
using EsitCV.Business.Abstract;
using EsitCV.Business.AbstractUtilities;
using EsitCV.Business.Concrete;
using EsitCV.Business.Utilities;
using EsitCV.Data.Concrete.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsitCV.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<EsitCVContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IJwtHelper, JwtHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerService, LoggerManager>();


            services.AddScoped<ICurriculumVitaeService, CurriculumVitaeManager>();
            services.AddScoped<IAwsStorageService, AwsStorageManager>();
            services.AddScoped<IJobPosingService, JobPosingManager>();
            services.AddScoped<IJobApplicationService, JobApplicationManager>();
            services.AddScoped<IJwtHelper, JwtHelper>();
            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IAnswerService, AnswerManager>();


            return services;

        }
    }
}
