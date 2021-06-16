namespace MercuryApi.Models
{
    public class JsonResponse
    {
        public BitstampExchange BitstampExchange { get; set; }
        public ExchangeRate ExchangeRate { get; set; }
        public ValrExchange ValrExchange { get; set; }
        public double Arbitrage { get; set; }
    }
}
