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
    /// <summary>
    /// Endpoint returning details for a package in the steam store.</summary>  
    public static class PackageDetails
    {
        private static HttpClient client = new HttpClient();
        private const string steamBaseUri = "http://store.steampowered.com/api/packagedetails";

        /// <summary>
        /// Retrieves details for the specified package via an asynchronous operation.</summary>  
        /// <param name="PackageId">Steam package ID.</param>
        public static async Task<PackageInfo> GetAsync(int PackageId)
        {
            return await GetAsync(PackageId, null, null);
        }

        /// <summary>
        /// Retrieves details for the specified package via an asynchronous operation.</summary>  
        /// <param name="PackageId">Steam package ID.</param>
        /// <param name="CountryCode">Two letter country code to customise currency and date values.</param>
        public static async Task<PackageInfo> GetAsync(int PackageId, string CountryCode)
        {
            return await GetAsync(PackageId, CountryCode, null);
        }

        /// <summary>
        /// Retrieves details for the specified package via an asynchronous operation.</summary>  
        /// <param name="PackageId">Steam package ID.</param>
        /// <param name="CountryCode">Two letter country code to customise currency and date values.</param>
        /// <param name="Language">Full name of the language in english used for string localization e.g. title, description, release dates.</param>
        public static async Task<PackageInfo> GetAsync(int PackageId, string CountryCode, string Language)
        {
            string steamUri = $"{steamBaseUri}?packageids={PackageId}";
            steamUri = string.IsNullOrWhiteSpace(CountryCode) ? steamUri : $"{steamUri}&cc={CountryCode}";
            steamUri = string.IsNullOrWhiteSpace(Language) ? steamUri : $"{steamUri}&l={Language.ToLower()}";

            var response = await client.GetAsync(steamUri);
            if (!response.IsSuccessStatusCode) { return null; }

            var result = await response.Content.ReadAsStringAsync();

            // The actual payload is wrapped, drill down to the third level to get to it
            var jsonData = JToken.Parse(result).First.First;
            if (!bool.Parse(jsonData["success"].ToString())) { return null; }

            var package = jsonData["data"].ToObject<PackageInfo>();
            package.SteamPackageId = PackageId;
            return package;
        }
    }
}
