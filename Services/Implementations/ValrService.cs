using System;
using System.Threading.Tasks;
using MercuryApi.Config;
using MercuryApi.Models;
using MercuryApi.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Refit;

namespace MercuryApi.Services.Implementations
{
    public class ValrService : IValrService
    {
        readonly IOptions<BaseUrls> _options;
        readonly IValrService _valrService;

        public ValrService(IOptions<BaseUrls> options)
        {
            _options = options;
            _valrService = RestService.For<IValrService>(_options.Value.ValrBaseUrl);
        }

        public async Task<ValrExchange> GetValrValue(string zarbid)
        {
            try
            {
                return await _valrService.GetValrValue(zarbid);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
