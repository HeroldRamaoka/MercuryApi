using MercuryAp.Models.Dtos;

namespace MercuryApi.Models.Dtos
{
    public class JsonResponseDto
    {
        public BitstampExchangeDto BitstampExchange { get; set; }
        public ExchangeRateDto ExchangeRate { get; set; }
        public ValrExchangeDto ValrExchange { get; set; }
        public double Arbitrage { get; set; }
    }
}
