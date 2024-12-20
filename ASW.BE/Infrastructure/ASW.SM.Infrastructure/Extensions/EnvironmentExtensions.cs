using Microsoft.Extensions.Hosting;
using ASW.SM.Infrastructure.Constants;

namespace ASW.SM.Infrastructure.Extensions
{
    public static class EnvironmentExtensions
    {
        public static bool IsDevEnv(this IHostEnvironment value)
        {
            return (value.IsDevelopment() |
                value.IsEnvironment(CoreConstant.DOCKER_DEV_ENV) |
                value.IsEnvironment(CoreConstant.DOCKER_LOCAL_ENV));
        }
    }
}
