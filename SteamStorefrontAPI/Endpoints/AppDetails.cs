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
    public static class AppDetails
    {
        private static HttpClient client = new HttpClient();
        private const string steamBaseUri = "http://store.steampowered.com/api/appdetails";

        public static async Task<SteamApp> GetAsync(int AppId)
        {
            return await GetAsync(AppId, "", "");
        }

        public static async Task<SteamApp> GetAsync(int AppId, string CountryCode)
        {
            return await GetAsync(AppId, CountryCode, "");
        }

        public static async Task<SteamApp> GetAsync(int AppId, string CountryCode, string Language)
        {
            string steamUri = $"{steamBaseUri}?appids={AppId}";
            steamUri = string.IsNullOrWhiteSpace(CountryCode) ? steamUri : $"{steamUri}&cc={CountryCode}";
            steamUri = string.IsNullOrWhiteSpace(Language) ? steamUri : $"{steamUri}&l={Language}";

            var response = await client.GetAsync(steamUri);
            if (!response.IsSuccessStatusCode) { return null; }

            var result = await response.Content.ReadAsStringAsync();

            // The actual payload is wrapped, drill down to the third level to get to it
            var jsonData = JToken.Parse(result).First.First;
            if (!bool.Parse(jsonData["success"].ToString())) { return null; }

            return jsonData["data"].ToObject<SteamApp>();
        }
    }
}
