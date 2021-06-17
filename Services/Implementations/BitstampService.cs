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
    public class BitstampService : IBitstampService
    {
        readonly IOptions<BaseUrls> _options;
        readonly IBitstampService _bitstampService;

        public BitstampService(IOptions<BaseUrls> options)
        {
            _options = options;
            _bitstampService = RestService.For<IBitstampService>(_options.Value.BitstampBaseUrl,
                new RefitSettings
                {
                    ContentSerializer = new NewtonsoftJsonContentSerializer(
                    new JsonSerializerSettings
                    {

                    ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        }
                )});
        }

        public async Task<BitstampExchange> GetBitstampValue(string usdAsk)
        {
            return await _bitstampService.GetBitstampValue(usdAsk);
        }
    }
}
