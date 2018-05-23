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
        public long Status { get; set; }

        public static SteamFeatured FromJson(string json) => JsonConvert.DeserializeObject<SteamFeatured>(json, Converter.Settings);
    }


    public enum ControllerSupport { Full };

    public enum Currency { Eur };

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
                new CurrencyConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ControllerSupportConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ControllerSupport) || t == typeof(ControllerSupport?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "full")
            {
                return ControllerSupport.Full;
            }
            throw new Exception("Cannot unmarshal type ControllerSupport");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ControllerSupport)untypedValue;
            if (value == ControllerSupport.Full)
            {
                serializer.Serialize(writer, "full"); return;
            }
            throw new Exception("Cannot marshal type ControllerSupport");
        }
    }

    internal class CurrencyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Currency) || t == typeof(Currency?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "EUR")
            {
                return Currency.Eur;
            }
            throw new Exception("Cannot unmarshal type Currency");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Currency)untypedValue;
            if (value == Currency.Eur)
            {
                serializer.Serialize(writer, "EUR"); return;
            }
            throw new Exception("Cannot marshal type Currency");
        }
    }
}
