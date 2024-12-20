using ASW.SM.Infrastructure.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace ASW.SM.Infrastructure.Extensions
{
    public static class StringHelpersExtensions
    {
        private static IConfiguration? Configuration;
        public static string GetValueOrDefault(this string? value, string defaultValue)
        {
            return String.IsNullOrEmpty(value) ? defaultValue : value;
        }
        public static string GetStringDefaultOrFromEnvValue(this string? value, string evnName, string defaultValue = "")
        {
            string? envValue = Environment.GetEnvironmentVariable(evnName);
            return !string.IsNullOrEmpty(envValue) ? envValue
                   : !string.IsNullOrEmpty(value) ? value
                   : defaultValue;
        }
        public static List<string> GetListStringDefaultOrFromEnvValue(this List<string>? value, string evnName, string defaultValue = "", char splitChar = ',')
        {
            string? envValue = Environment.GetEnvironmentVariable(evnName);
            return !string.IsNullOrEmpty(envValue) ? envValue.Split(splitChar).ToList()
                   : value != null && value.Any() ? value
                   : defaultValue.Split(splitChar).ToList();
        }

        public static int ToInt(this string value, int _default = 0)
        {
            try
            {
                return int.Parse(value);
            }
            catch
            {
                return _default;
            }
        }

        public static DateTime ToDateTime(this string value, string format)
        {
            try
            {
                return DateTime.ParseExact(value, format, CultureInfo.InvariantCulture);
            }
            catch
            {
                return default;
            }
        }

        public static long ToLong(this string value, long _default = 0)
        {
            try
            {
                return long.Parse(value);
            }
            catch
            {
                return _default;
            }
        }

        public static bool DateTimeContain(this string? value, DateTime? input)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (input == null) return false;
            try
            {
                value.Replace("/", "-");
                value.Replace("\\", "-");
                var temp = input.Value.ToString("yyyy-MM-dd HH:mm:ss");
                return temp.Contains(value.Trim());
            }
            catch { return false; }
        }

        public static bool NumberContain(this string? value, decimal? input)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (input == null) return false;
            try
            {
                var temp = input.Value.ToString();
                return temp.Contains(value.Trim());
            }
            catch { return false; }
        }

        public static bool StringContain(this string? value, string? input)
        {
            if (string.IsNullOrEmpty(value)) return false;
            if (input == null) return false;
            try
            {
                return input.ToUpper().Trim().Contains(value.ToUpper().Trim());
            }
            catch { return false; }
        }

        public static DateTimeOffset? DateTimeFromUnixTimeSeconds(this string value)
        {
            try
            {
                long unixTimestamp = value.ToLong();
                if (unixTimestamp == 0)
                    return null;

                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
                return dateTimeOffset.UtcDateTime;
            }
            catch
            {
                return null;
            }
        }

        public static string[] SplitAndRemoveEmpty(this string value, char separator = CoreConstant.SYSTEM_SEPARATOR_CHAR)
        {
            return value.SplitAndRemoveEmpty(new char[] { separator });
        }
        public static string[] SplitAndRemoveEmpty(this string value, char[] separators)
        {
            return value.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool YesNoToBool(this string yesNoVal)
        {
            return CoreConstant.FLAG_YES.EqualsIgnoreCase(yesNoVal);
        }

        public static bool EqualsIgnoreCase(this string firstString, string secondString)
        {
            return firstString.Equals(secondString, StringComparison.InvariantCultureIgnoreCase);
        }

        public static string NormalizeUrl(this string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                var urlNormalized = !url.EndsWith('/') ? url : url.TrimEnd('/');

                return urlNormalized;
            }
            return "";
        }

        public static string NormalizeWithDetailUrl(this string? url, string detail)
        {
            if ((!string.IsNullOrEmpty(url)) && (!string.IsNullOrEmpty(detail)))
            {
                var urlNormalized = !url.EndsWith('/') ? url : url.TrimEnd('/');
                var detailNormalized = !detail.StartsWith('/') ? detail : detail.TrimStart('/');
                detailNormalized = !detailNormalized.EndsWith('/') ? detailNormalized : detailNormalized.TrimEnd('/');

                return $"{urlNormalized}/{detailNormalized}";
            }
            return "";
        }

        public static Guid ToGuid(this string? value)
        {
            if (!string.IsNullOrEmpty(value))
                return Guid.Parse(value);
            else
                return Guid.Empty;
        }
        public static string JoinString(this List<string> input)
        {
            var rlt = input != null && input.Any() ? string.Join(", ", input) : "";
            if(string.IsNullOrEmpty(rlt))
            {
                rlt = rlt.Replace(", ,", "");
                rlt = rlt.Replace(", ,", "");
                rlt = rlt.Trim();
                rlt = rlt.Substring(0, rlt.Length - 1);
            }
            return rlt;
        }
    }
}
