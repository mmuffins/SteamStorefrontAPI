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
    public class SteamApp : IEquatable<SteamApp>
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steam_appid")]
        public int SteamAppId { get; set; }

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
        public List<string> Developers { get; }

        [JsonProperty("publishers")]
        public List<string> Publishers { get; }

        [JsonProperty("price_overview")]
        public PriceOverview PriceOverview { get; set; }

        [JsonProperty("packages")]
        public List<long> Packages { get;  }

        [JsonProperty("package_groups")]
        public List<PackageGroup> PackageGroups { get; }

        [JsonProperty("platforms")]
        public Platforms Platforms { get; set; }

        [JsonProperty("categories")]
        public List<Category> Categories { get; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; }

        [JsonProperty("screenshots")]
        public List<Screenshot> Screenshots { get; }

        [JsonProperty("movies")]
        public List<Movie> Movies { get; }

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
        public List<int> DLC { get; }

        [JsonProperty("reviews")]
        public string Reviews { get; set; }

        public SteamApp()
        {
            this.Developers = new List<string>();
            this.Publishers = new List<string>();
            this.Packages = new List<long>();
            this.PackageGroups = new List<PackageGroup>();
            this.Categories = new List<Category>();
            this.Genres = new List<Genre>();
            this.Screenshots = new List<Screenshot>();
            this.Movies = new List<Movie>();
            this.DLC = new List<int>();
        }

        public static SteamApp FromJson(string json)
        {

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

        public bool Equals(SteamApp other)
        {
            if (other == null)
                return false;

            if (this.SteamAppId == other.SteamAppId && this.Type == other.Type)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            SteamApp personObj = obj as SteamApp;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override int GetHashCode() => this.SteamAppId.GetHashCode();

        public override string ToString() => Name;
    }
}
