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

    public class PackageGroup
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("selection_text")]
        public string SelectionText { get; set; }

        [JsonProperty("save_text")]
        public string SaveText { get; set; }

        [JsonProperty("display_type")]
        public long DisplayType { get; set; }

        [JsonProperty("is_recurring_subscription")]
        public string IsRecurringSubscription { get; set; }

        [JsonProperty("subs")]
        public List<Sub> Subs { get; }

        public PackageGroup()
        {
            this.Subs = new List<Sub>();
        }
    }
}
