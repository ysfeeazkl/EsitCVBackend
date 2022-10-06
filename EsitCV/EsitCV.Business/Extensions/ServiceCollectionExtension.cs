using E_Commerce.Business.Abstract;
using E_Commerce.Business.AbstractUtilities;
using E_Commerce.Business.Concrete;
using E_Commerce.Business.Utilities;
using E_Commerce.Data.Concrete.Context;
using EsitCV.Data.Concrete.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<EsitCVContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ILoggerService, LoggerManager>();

            services.AddScoped<IJwtHelper, JwtHelper>();


            return services;

        }
    }
}
