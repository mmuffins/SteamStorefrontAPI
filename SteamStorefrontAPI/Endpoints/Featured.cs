using Newtonsoft.Json.Linq;
using SteamStorefrontAPI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SteamStorefrontAPI
{
    public static class Featured
    {
        private static HttpClient client = new HttpClient();
        private const string steamBaseUri = "https://store.steampowered.com/api/featured";


        public static async Task<FeaturedApps> GetAsync()
        {
            return await GetAsync(null, null);
        }

        public static async Task<FeaturedApps> GetAsync(string CountryCode)
        {
            return await GetAsync(CountryCode, null);
        }

        public static async Task<FeaturedApps> GetAsync(string CountryCode, string Language)
        {
            string steamUri = steamBaseUri;
            steamUri = CountryCode is null ? steamUri : $"{steamUri}&cc={CountryCode}";
            steamUri = Language is null ? steamUri : $"{steamUri}&l={Language}";

            var response = await client.GetAsync(steamUri);
            if (!response.IsSuccessStatusCode) { return null; }

            var result = await response.Content.ReadAsStringAsync();

            var jsonData = JToken.Parse(result);
            if (jsonData["status"].ToString() != "1") { return null; }

            return FeaturedApps.FromJson(result);
        }
    }
}
