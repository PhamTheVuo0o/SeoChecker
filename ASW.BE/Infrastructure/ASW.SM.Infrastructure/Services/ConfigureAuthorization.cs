using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ASW.SM.Infrastructure.Enums;
using ASW.SM.Infrastructure.Models;
using ASW.SM.Infrastructure.Security;

namespace ASW.SM.Infrastructure.Services
{
    public static class ConfigureAuthorization
    {
        public static IServiceCollection AddCustomAuthorization(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationFilter, CustomAuthorizeAttribute>();
            return services;
        }
    }
}
