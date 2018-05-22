using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SteamStorefrontAPI
{
    public class PriceOverview
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("initial")]
        [JsonConverter(typeof(LongToDoubleConverter))]
        public double Initial { get; set; }

        [JsonProperty("final")]
        [JsonConverter(typeof(LongToDoubleConverter))]
        public double Final { get; set; }

        [JsonProperty("discount_percent")]
        public int DiscountPercent { get; set; }
    }

    public class LongToDoubleConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            long longValue = long.Parse(reader.Value.ToString());
            double convertedValue = longValue / 100.0;
            return convertedValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanRead is CanWrite. The type will skip the converter.");
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }
    }

    public class PriceOverviewSerializer : JsonSerializer
    {

    }

}
