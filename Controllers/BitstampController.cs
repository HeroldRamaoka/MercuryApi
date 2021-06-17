using System;
using System.Threading.Tasks;
using AutoMapper;
using MercuryAp.Models.Dtos;
using MercuryApi.Config;
using MercuryApi.Helper;
using MercuryApi.Models;
using MercuryApi.Models.Dtos;
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
        readonly IMapper _mapper;

        public JsonResponseDto JsonResponseDto { get; set; }

        public BitstampController(IBitstampService bitstampService, 
                                  IValrService valrService, 
                                  IMapper mapper,
                                  IExchangeRateService exchangeRateService, 
                                  IOptions<ApiKey> options)
        {
            _bitstampService = bitstampService;
            _valrService = valrService;
            _exchangeRateService = exchangeRateService;
            _options = options;
            _mapper = mapper;
        }

        [HttpGet("calculateBitstampArbitrage")]
        public async Task<ActionResult> CalculateBitstampArbitrage()
        {
            var bitstampExchange = await _bitstampService.GetBitstampValue(Const.btcusd);
            var valrExchange = await _valrService.GetValrValue(Const.BTCZAR);
            var exchangeRate = await _exchangeRateService.GetExchangeRate(_options.Value.Key);

            //var arbitrage = float.Parse(valrExchange.BidPrice) / (float.Parse(bitstampExchange.Ask) * exchangeRate.conversion_rate);

            var jsonResponse = new JsonResponse()
            {
                BitstampExchange = bitstampExchange,
                ValrExchange = valrExchange,
                ExchangeRate = exchangeRate
                //Arbitrage = arbitrage
            };

            var result = _mapper.Map<JsonResponseDto>(jsonResponse);

            return Ok(result);
        }
    }
}
