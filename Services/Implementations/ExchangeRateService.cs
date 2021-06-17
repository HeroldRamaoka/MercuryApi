using System.Threading.Tasks;
using MercuryApi.Config;
using MercuryApi.Models;
using MercuryApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace MercuryApi.Services.Implementations
{
    public class ExchangeRateService : IExchangeRateService
    {
        readonly IOptions<BaseUrls> _options;
        readonly IExchangeRateService _exchangeRateService;

        public ExchangeRateService(IOptions<BaseUrls> options)
        {
            _options = options;
            _exchangeRateService = RestService.For<IExchangeRateService>(_options.Value.ExchangeRateBaseUrl,
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {

                        ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
                    }
                )
                });
        }

        public async Task<ExchangeRate> GetExchangeRate(string apiKey)
        {
            return await _exchangeRateService.GetExchangeRate(apiKey);
        }
    }
}
