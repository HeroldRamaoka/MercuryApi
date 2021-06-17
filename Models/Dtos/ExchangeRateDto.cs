using Newtonsoft.Json;

namespace MercuryApi.Models.Dtos
{
    public class ExchangeRateDto
    {
        public string Result { get; set; }
        public string Documentation { get; set; }
        public string TermsOfUse { get; set; }
        public string TimeLastUpdateUnix { get; set; }
        public string TimeLastUpdateUtc { get; set; }
        public string TimeNextUpdateUnix { get; set; }
        public string BaseCode { get; set; }
        public string TimeNextUpdateUtc { get; set; }
        public string TargetCode { get; set; }
        public double ConversionRate { get; set; }
    }
}
