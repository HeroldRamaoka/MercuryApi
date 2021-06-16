using System.Threading.Tasks;
using MercuryApi.Models;
using Refit;

namespace MercuryApi.Services.Interfaces
{
    public interface IValrService
    {
        [Get("/{zarbid}/marketsummary")]
        Task<ValrExchange> GetValrValue(string zarbid);
    }
}
