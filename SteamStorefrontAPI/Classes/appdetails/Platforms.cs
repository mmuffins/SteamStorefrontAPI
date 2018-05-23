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
    public class Platforms
    {
        [JsonProperty("windows")]
        public bool Windows { get; set; }

        [JsonProperty("mac")]
        public bool Mac { get; set; }

        [JsonProperty("linux")]
        public bool Linux { get; set; }
    }

}
