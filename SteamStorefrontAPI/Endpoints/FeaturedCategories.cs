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
    public static class FeaturedCategories
    {
        private static HttpClient client = new HttpClient();
        private const string steamBaseUri = "https://store.steampowered.com/api/featuredcategories";

        public static async Task<List<FeaturedCategory>> GetAsync()
        {
            return await GetAsync(null, null);
        }

        public static async Task<List<FeaturedCategory>> GetAsync(string CountryCode)
        {
            return await GetAsync(CountryCode, null);
        }

        public static async Task<List<FeaturedCategory>> GetAsync(string CountryCode, string Language)
        {
            string steamUri = steamBaseUri;
            steamUri = string.IsNullOrWhiteSpace(CountryCode) ? steamUri : $"{steamUri}&cc={CountryCode}";
            steamUri = string.IsNullOrWhiteSpace(Language) ? steamUri : $"{steamUri}&l={Language}";

            var response = await client.GetAsync(steamUri);
            if (!response.IsSuccessStatusCode) { return null; }

            var result = await response.Content.ReadAsStringAsync();

            var jsonData = JObject.Parse(result);
            if (jsonData["status"].ToString() != "1") { return null; }

            var featuredCatList = new List<FeaturedCategory>();

            jsonData.Remove("status");

            foreach (var item in jsonData.Children())
            {
                featuredCatList.Add(item.First.ToObject<FeaturedCategory>());
            }

            return featuredCatList;
        }
    }
}
