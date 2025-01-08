using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class WebSearchHelpers
{
    public static async Task<List<string>> GetWebSearchResultUrlsAsync(WebSearchProvider webSearchProvider, string query, int maxResults, List<Regex> excludeURLContainsPatternList, bool headless)
    {
        var providerString = webSearchProvider.ToString().ToLower();
        return webSearchProvider == WebSearchProvider.BingAPI
            ? await BingApiWebSearchHelpers.GetWebSearchResultUrlsAsync(query, maxResults, excludeURLContainsPatternList, headless)
            : await PlaywrightHelpers.GetWebSearchResultUrlsAsync(providerString, query, maxResults, excludeURLContainsPatternList, headless);
    }
}