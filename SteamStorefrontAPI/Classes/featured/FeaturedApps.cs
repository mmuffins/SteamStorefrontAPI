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
    public class FeaturedApps
    {
        [JsonProperty("large_capsules")]
        public List<AppInfo> LargeCapsules { get; }

        [JsonProperty("featured_win")]
        public List<AppInfo> FeaturedWin { get; }

        [JsonProperty("featured_mac")]
        public List<AppInfo> FeaturedMac { get; }

        [JsonProperty("featured_linux")]
        public List<AppInfo> FeaturedLinux { get; }

        [JsonProperty("layout")]
        public string Layout { get; set; }

        //[JsonProperty("status")]
        //public int Status { get; set; }

        public FeaturedApps()
        {
            this.LargeCapsules = new List<AppInfo>();
            this.FeaturedWin = new List<AppInfo>();
            this.FeaturedMac = new List<AppInfo>();
            this.FeaturedLinux = new List<AppInfo>();
        }

        public static FeaturedApps FromJson(string json)
        {

            var serializerSettings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new ControllerSupportConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };

            return JsonConvert.DeserializeObject<FeaturedApps>(json, serializerSettings);
        }
    }
}
