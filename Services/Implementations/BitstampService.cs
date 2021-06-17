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
            _bitstampService = RestService.For<IBitstampService>(_options.Value.BitstampBaseUrl);
        }

        public async Task<BitstampExchange> GetBitstampValue(string usdAsk)
        {
            try
            {
                return await _bitstampService.GetBitstampValue(usdAsk);
            }
            catch
            {
                throw new System.Exception();
            }
        }
    }
}
