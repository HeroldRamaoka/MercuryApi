namespace MercuryApi.Models.Dtos
{
    public class ValrExchangeDto
    {
        public string CurrencyPair { get; set; }
        public string AskPrice { get; set; }
        public string BidPrice { get; set; }
        public string lastTradedPrice { get; set; }
        public string previousClosePrice { get; set; }
        public string BaseVolume { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string Created { get; set; }
        public string ChangeFromPrevious { get; set; }
    }
}
