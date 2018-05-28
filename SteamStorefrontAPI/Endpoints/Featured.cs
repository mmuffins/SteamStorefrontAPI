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
    /// Endpoint returning a list of featured items in the steam store.</summary>  
    public static class Featured
    {
        private static HttpClient client = new HttpClient();
        private const string steamBaseUri = "https://store.steampowered.com/api/featured";

        /// <summary>
        /// Retrieves a list of featured items via an asynchronous operation.</summary>  
        public static async Task<FeaturedApps> GetAsync()
        {
            return await GetAsync(null, null);
        }

        /// <summary>
        /// Retrieves a list of featured items via an asynchronous operation.</summary>  
        /// <param name="CountryCode">Two letter country code to customise currency and date values.</param>
        public static async Task<FeaturedApps> GetAsync(string CountryCode)
        {
            return await GetAsync(CountryCode, null);
        }

        /// <summary>
        /// Retrieves a list of featured items via an asynchronous operation.</summary>  
        /// <param name="CountryCode">Two letter country code to customise currency and date values.</param>
        /// <param name="Language">Full name of the language in english used for string localization e.g. name, description.</param>
        public static async Task<FeaturedApps> GetAsync(string CountryCode, string Language)
        {
            string steamUri = steamBaseUri;
            steamUri = string.IsNullOrWhiteSpace(CountryCode) ? steamUri : $"{steamUri}?cc={CountryCode}";

            if (!string.IsNullOrWhiteSpace(Language))
            {
                steamUri += string.IsNullOrWhiteSpace(CountryCode) ? "?" : "&";
                steamUri += $"l={Language.ToLower()}";
            }

            var response = await client.GetAsync(steamUri);
            if (!response.IsSuccessStatusCode) { return null; }

            var result = await response.Content.ReadAsStringAsync();

            var jsonData = JToken.Parse(result);
            if (jsonData["status"].ToString() != "1") { return null; }

            return FeaturedApps.FromJson(result);
        }
    }
}
