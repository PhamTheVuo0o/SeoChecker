using ASW.SM.Infrastructure.DataSync.Contracts;
using ASW.SM.Infrastructure.DataSync.Implementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASW.SM.Infrastructure.DataSync.Services
{
    public static class ConfigureDataSync
    {
        public static IServiceCollection ConfigureDataSyncServices(this IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();

            services.AddTransient<GoogleSearchEngine>();
            services.AddTransient<BingSearchEngine>();

            services.AddTransient<ISearchEngine, GoogleSearchEngine>();
            services.AddTransient<ISearchEngine, BingSearchEngine>();

            return services;
        }
    }
}
