using Newtonsoft.Json;

namespace MercuryApi.Models.Dtos
{
    public class ExchangeRateDto
    {
        public string Result { get; set; }
        public string Documentation { get; set; }
        [JsonProperty("terms_of_use")]
        public string TermsOfUse { get; set; }
        [JsonProperty("time_last_update_unix")]
        public string TimeLastUpdateUnix { get; set; }
        [JsonProperty("time_last_update_utc")]
        public string TimeLastUpdateUtc { get; set; }
        [JsonProperty("time_next_update_unix")]
        public string TimeNextUpdateUnix { get; set; }
        [JsonProperty("base_code")]
        public string base_code { get; set; }
        public string time_next_update_utc { get; set; }
        public string target_code { get; set; }
        public double conversion_rate { get; set; }
    }
}
