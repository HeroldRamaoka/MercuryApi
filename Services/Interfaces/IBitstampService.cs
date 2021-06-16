using System.Threading.Tasks;
using MercuryApi.Models;
using Refit;

namespace MercuryApi.Services.Interfaces
{
    public interface IBitstampService
    {
        [Get("/{usdAsk}/")]
        Task<BitstampExchange> GetBitstampValue(string usdAsk);
    }
}
