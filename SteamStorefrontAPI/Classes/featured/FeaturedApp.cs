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
    public enum ControllerSupport { Full, Partial };

    public class FeaturedApp
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("discounted")]
        public bool Discounted { get; set; }

        [JsonProperty("discount_percent")]
        public int DiscountPercent { get; set; }

        [JsonProperty("original_price")]
        [JsonConverter(typeof(SteamPriceStringConverter))]
        public double? OriginalPrice { get; set; }

        [JsonProperty("final_price")]
        [JsonConverter(typeof(SteamPriceStringConverter))]
        public double? FinalPrice { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("large_capsule_image")]
        public string LargeCapsuleImage { get; set; }

        [JsonProperty("small_capsule_image")]
        public string SmallCapsuleImage { get; set; }

        [JsonProperty("windows_available")]
        public bool WindowsAvailable { get; set; }

        [JsonProperty("mac_available")]
        public bool MacAvailable { get; set; }

        [JsonProperty("linux_available")]
        public bool LinuxAvailable { get; set; }

        [JsonProperty("streamingvideo_available")]
        public bool StreamingvideoAvailable { get; set; }

        [JsonProperty("header_image")]
        public string HeaderImage { get; set; }

        [JsonProperty("discount_expiration", NullValueHandling = NullValueHandling.Ignore)]
        public long? DiscountExpiration { get; set; }

        [JsonProperty("controller_support", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ControllerSupportConverter))]
        public ControllerSupport? ControllerSupport { get; set; }
    }
}
