using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamStorefrontAPI.Classes
{
    // Converts price strings to double, e.g. 2599 => 25.99
    public class SteamPriceStringConverter : JsonConverter
    {
        public override bool CanRead
        {
            get => true;
        }

        public override bool CanWrite
        {
            get => false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = reader.Value.ToString();

            if(value.Length < 2)
            {
                return double.Parse($".{value}");
            }

            return double.Parse(value.Insert(value.Length - 2, "."));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }

    // Converts a string to a ControllerSupport enum
    internal class ControllerSupportConverter : JsonConverter
    {
        public override bool CanRead
        {
            get => true;
        }

        public override bool CanConvert(Type t) => t == typeof(ControllerSupport) || t == typeof(ControllerSupport?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);

            ControllerSupport convertedValue;
            if(Enum.TryParse(value, out convertedValue))
            {
                return convertedValue;
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
