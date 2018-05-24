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
    public class PriceOverview
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("initial")]
        [JsonConverter(typeof(SteamPriceStringConverter))]
        public double Initial { get; set; }

        [JsonProperty("final")]
        [JsonConverter(typeof(SteamPriceStringConverter))]
        public double Final { get; set; }

        [JsonProperty("discount_percent")]
        public int DiscountPercent { get; set; }

        [JsonProperty("individual", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(SteamPriceStringConverter))]
        public double Individual { get; set; }
    }
}
