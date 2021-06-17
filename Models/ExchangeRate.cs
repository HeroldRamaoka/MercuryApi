using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MercuryApi.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ExchangeRate
    {
        public string Result { get; set; }
        public string Documentation { get; set; }
        [JsonProperty(PropertyName = "terms_of_use")]
        public string TermsOfUse { get; set; }
        [JsonProperty(PropertyName =  "time_last_update_unix")]
        public string TimeLastUpdateUnix { get; set; }
        [JsonProperty(PropertyName = "time_last_update_utc")]
        public string TimeLastUpdateUtc { get; set; }
        [JsonProperty("time_next_update_unix")]
        public string TimeNextUpdateUnix { get; set; }
        [JsonProperty(PropertyName = "base_code")]
        public string BaseCode { get; set; }
        [JsonProperty(PropertyName = "time_next_update_utc")]
        public string TimeNextUpdateUtc { get; set; }
        [JsonProperty(PropertyName = "target_code")]
        public string TargetCode { get; set; }
        [JsonProperty(PropertyName = "conversion_rate")]
        public double ConversionRate { get; set; }
    }
}
