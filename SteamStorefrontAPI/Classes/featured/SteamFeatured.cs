using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SteamStorefrontAPI.Classes
{
    public class SteamFeatured
    {
        [JsonProperty("large_capsules")]
        public List<object> LargeCapsules { get; set; }

        [JsonProperty("featured_win")]
        public List<FeaturedApp> FeaturedWin { get; set; }

        [JsonProperty("featured_mac")]
        public List<FeaturedApp> FeaturedMac { get; set; }

        [JsonProperty("featured_linux")]
        public List<FeaturedApp> FeaturedLinux { get; set; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }

        public static SteamFeatured FromJson(string json) => JsonConvert.DeserializeObject<SteamFeatured>(json, Converter.Settings);
    }



    public static class Serialize
    {
        public static string ToJson(this SteamFeatured self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new ControllerSupportConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

}
