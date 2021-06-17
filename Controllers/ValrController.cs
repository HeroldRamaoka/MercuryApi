using System;
using System.Threading.Tasks;
using AutoMapper;
using MercuryAp.Models.Dtos;
using MercuryApi.Config;
using MercuryApi.Models;
using MercuryApi.Models.Dtos;
using MercuryApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MercuryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValrController : ControllerBase
    {
        readonly IBitstampService _bitstampService;
        readonly IValrService _valrService;
        readonly IExchangeRateService _exchangeRateService;
        readonly IOptions<ApiKey> _options;
        readonly IMapper _mapper;

        public ValrController(IBitstampService bitstampService, IValrService valrService, IMapper mapper,
                                  IExchangeRateService exchangeRateService, IOptions<ApiKey> options)
        {
            _bitstampService = bitstampService;
            _valrService = valrService;
            _exchangeRateService = exchangeRateService;
            _options = options;
            _mapper = mapper;
        }

        [HttpGet("calculateXrpArbitrage")]
        public async Task<ActionResult> CalculateXrpArbitrage()
        {
            var bitstampExchange = await _bitstampService.GetBitstampValue("xrpusd");
            var valrExchange = await _valrService.GetValrValue("XRPZAR");
            var exchangeRate = await _exchangeRateService.GetExchangeRate(_options.Value.Key);


            var arbitrage = Convert.ToDouble(valrExchange.BidPrice) / (Convert.ToDouble(bitstampExchange.Ask) * exchangeRate.conversion_rate);

            var jsonResponse = new JsonResponse()
            {
                BitstampExchange = bitstampExchange,
                ValrExchange = valrExchange,
                ExchangeRate = exchangeRate,
                Arbitrage = arbitrage
            };

            var result = _mapper.Map<JsonResponseDto>(jsonResponse);

            return Ok(result);
        }
    }
}
