using MercuryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercuryApi.Services.Interfaces
{
    interface IBitstampService
    {
        Task<BitstampExchange> GetBitstampValue();
    }
}
