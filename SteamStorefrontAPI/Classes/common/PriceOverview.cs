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
    public class PriceOverview : IEquatable<PriceOverview>
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

        public bool Equals(PriceOverview other)
        {
            if (other == null)
                return false;

            if (this.Final == other.Final
                && this.Currency == other.Currency
                && this.Initial == other.Initial)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            PriceOverview personObj = obj as PriceOverview;
            if (personObj == null)
                return false;
            else
                return Equals(personObj);
        }

        public override int GetHashCode()
        {
            return this.Final.GetHashCode() 
                ^ this.Initial.GetHashCode() 
                ^ this.Currency.GetHashCode();
        }

        public override string ToString() => Final.ToString() + " " + Currency;
    }
}
