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
    public class Achievements
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("highlighted")]
        public List<Highlighted> Highlighted { get; }

        public Achievements()
        {
            this.Highlighted = new List<Highlighted>();
        }
    }
}
