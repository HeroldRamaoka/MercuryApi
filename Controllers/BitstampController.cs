using System;
using System.Threading.Tasks;
using MercuryApi.Config;
using MercuryApi.Models;
using MercuryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MercuryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BitstampController : ControllerBase
    {
        readonly IBitstampService _bitstampService;
        readonly IValrService _valrService;
        readonly IExchangeRateService _exchangeRateService;
        readonly IOptions<ApiKey> _options;

        public BitstampController(IBitstampService bitstampService, IValrService valrService,
                                  IExchangeRateService exchangeRateService, IOptions<ApiKey> options)
        {
            _bitstampService = bitstampService;
            _valrService = valrService;
            _exchangeRateService = exchangeRateService;
            _options = options;
        }

        [HttpGet("calculateBitstampArbitrage")]
        public async Task<ActionResult> CalculateBitstampArbitrage()
        {
            var bitstampExchange = await _bitstampService.GetBitstampValue("btcusd");
            var valrExchange = await _valrService.GetValrValue("BTCZAR");
            var exchangeRate = await _exchangeRateService.GetExchangeRate(_options.Value.Key);

            var arbitrage = Convert.ToDouble(valrExchange.BidPrice) / (Convert.ToDouble(bitstampExchange.Ask) * exchangeRate.conversion_rate);

            var jsonResponse = new JsonResponse()
            {
                BitstampExchange = bitstampExchange,
                ValrExchange = valrExchange,
                ExchangeRate = exchangeRate,
                Arbitrage = arbitrage
            };

            return Ok(jsonResponse);
        }
    }
}
