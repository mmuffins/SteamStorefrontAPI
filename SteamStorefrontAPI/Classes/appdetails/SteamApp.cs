using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace SteamStorefrontAPI.Classes
{
    public class SteamApp
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steam_appid")]
        public int SteamAppid { get; set; }

        [JsonProperty("required_age")]
        public int RequiredAge { get; set; }

        [JsonProperty("is_free")]
        public bool IsFree { get; set; }

        [JsonProperty("detailed_description")]
        public string DetailedDescription { get; set; }

        [JsonProperty("about_the_game")]
        public string AboutTheGame { get; set; }

        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        [JsonProperty("supported_languages")]
        public string SupportedLanguages { get; set; }

        [JsonProperty("header_image")]
        public string HeaderImage { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("pc_requirements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RequirementsConverter))]
        public Requirements PcRequirements { get; set; }

        [JsonProperty("mac_requirements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RequirementsConverter))]
        public Requirements MacRequirements { get; set; }

        [JsonProperty("linux_requirements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(RequirementsConverter))]
        public Requirements LinuxRequirements { get; set; }

        [JsonProperty("legal_notice")]
        public string LegalNotice { get; set; }

        [JsonProperty("developers")]
        public List<string> Developers { get; set; }

        [JsonProperty("publishers")]
        public List<string> Publishers { get; set; }

        [JsonProperty("price_overview")]
        public PriceOverview PriceOverview { get; set; }

        [JsonProperty("packages")]
        public List<long> Packages { get; set; }

        [JsonProperty("package_groups")]
        public List<PackageGroup> PackageGroups { get; set; }

        [JsonProperty("platforms")]
        public Platforms Platforms { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("screenshots")]
        public List<Screenshot> Screenshots { get; set; }

        [JsonProperty("movies")]
        public List<Movie> Movies { get; set; }

        [JsonProperty("recommendations")]
        public Recommendations Recommendations { get; set; }

        [JsonProperty("achievements")]
        public Achievements Achievements { get; set; }

        [JsonProperty("release_date")]
        public ReleaseDate ReleaseDate { get; set; }

        [JsonProperty("support_info")]
        public SupportInfo SupportInfo { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("controller_support", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ControllerSupportConverter))]
        public ControllerSupport? ControllerSupport { get; set; }

        [JsonProperty("dlc")]
        public List<int> DLC { get; set; }

        [JsonProperty("reviews")]
        public string Reviews { get; set; }

        public static SteamApp FromJson(string json) {

            var serializerSettings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };

            return JsonConvert.DeserializeObject<SteamApp>(json, serializerSettings);
        }
    }
}
