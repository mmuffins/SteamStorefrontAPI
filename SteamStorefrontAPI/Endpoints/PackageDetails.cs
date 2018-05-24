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
    public static class PackageDetails
    {
        private static HttpClient client = new HttpClient();
        private const string steamBaseUri = "http://store.steampowered.com/api/packagedetails";

        public static async Task<PackageInfo> GetAsync(int PackageId)
        {
            return await GetAsync(PackageId, null, null);
        }

        public static async Task<PackageInfo> GetAsync(int PackageId, string CountryCode)
        {
            return await GetAsync(PackageId, CountryCode, null);
        }

        public static async Task<PackageInfo> GetAsync(int PackageId, string CountryCode, string Language)
        {
            string steamUri = $"{steamBaseUri}?packageids={PackageId}";
            steamUri = CountryCode is null ? steamUri : $"{steamUri}&cc={CountryCode}";
            steamUri = Language is null ? steamUri : $"{steamUri}&l={Language}";

            var response = await client.GetAsync(steamUri);
            if (!response.IsSuccessStatusCode) { return null; }

            var result = await response.Content.ReadAsStringAsync();

            // The actual payload is wrapped, drill down to the third level to get to it
            var jsonData = JToken.Parse(result).First.First;
            if (!bool.Parse(jsonData["success"].ToString())) { return null; }

            return jsonData["data"].ToObject<PackageInfo>();
        }
    }
}
