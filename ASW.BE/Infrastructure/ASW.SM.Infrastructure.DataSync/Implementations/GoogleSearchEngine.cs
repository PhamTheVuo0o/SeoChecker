using ASW.SM.Infrastructure.DataSync.Contracts;
using System.Text.RegularExpressions;

namespace ASW.SM.Infrastructure.DataSync.Implementations
{
    public class GoogleSearchEngine : ISearchEngine
    {
        private readonly HttpClient _httpClient;

        public GoogleSearchEngine(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<int>> SearchAsync(string keyword, string url)
        {
            var positions = new List<int>();
            var requestUrl = $"https://www.google.com/search?q={Uri.EscapeDataString(keyword)}";

            var response = await _httpClient.GetStringAsync(requestUrl);

            var matches = Regex.Matches(response, @"<a href=""\/url\?q=(http.+?)&amp;");
            if (matches.Count == 0) {
                matches = Regex.Matches(response, @"<a href=""\/url\?q=([^&]+)&");
            }

            int position = 1;
            foreach (Match match in matches)
            {
                var resultUrl = match.Groups[1].Value;

                if (resultUrl.Contains(url, StringComparison.OrdinalIgnoreCase))
                {
                    positions.Add(position);
                }

                if (position >= 100) break; 
                position++;
            }

            return positions.Count > 0 ? positions : new List<int> { 0 };
        }
    }
}
