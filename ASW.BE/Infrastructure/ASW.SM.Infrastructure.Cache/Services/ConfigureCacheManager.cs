using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ASW.SM.Infrastructure.Cache.Common;
using ASW.SM.Infrastructure.Cache.Contracts;
using ASW.SM.Infrastructure.Cache.Implementations;

namespace ASW.SM.Infrastructure.Cache.Services
{
    public static class ConfigureCacheManager
    {
        public static IServiceCollection ConfigureCacheManagerServices(this IServiceCollection services,
            IConfiguration config)
        {
            var cacheSettings = new CacheSettings();
            config.GetSection("CacheSettings").Bind(cacheSettings);
            if (cacheSettings.UseDistributedCache)
            {
                // Distributed cache - such as Redis will be default
            }
            else
            {
                // Memory cache will be default
                services.AddSingleton<IMemoryCache, MemoryCache>();
                services.AddSingleton<ICacheManager, MemoryCacheManager>();
            }
            return services;
        }
    }
}
