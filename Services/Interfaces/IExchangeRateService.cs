using System;
using System.Threading.Tasks;
using MercuryApi.Models;
using Refit;

namespace MercuryApi.Services.Interfaces
{
    public interface IExchangeRateService
    {
        [Get("/{apiKey}/pair/USD/ZAR")]
        Task<ExchangeRate> GetExchangeRate(string apiKey);
    }
}
