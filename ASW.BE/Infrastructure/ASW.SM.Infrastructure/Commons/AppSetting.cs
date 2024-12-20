using ASW.SM.Infrastructure.Extensions;
using ASW.SM.Infrastructure.Constants;

namespace ASW.SM.Infrastructure.Common
{
    public class AppSetting
    {
        public List<string> AllowedHosts { get; set; }
        public string? JWTSecret64Symbol { get; set; }

        public string GetJWTSecret64Symbol => JWTSecret64Symbol.
            GetStringDefaultOrFromEnvValue(CoreConstant.JWT_SECRET_64_SYMBOL);

        public AppSetting()
        {
            AllowedHosts = new List<string>();
        }
    }
}
