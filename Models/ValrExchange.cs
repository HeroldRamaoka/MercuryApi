using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercuryApi.Models
{
    public class ValrExchange
    {
        public string CurrencyPair { get; set; }
        public string AskPrice { get; set; }
        public string BidPrice { get; set; }
        public string lastTradedPrice { get; set; }
        public string previousClosePrice { get; set; }
        public string BaseVolume { get; set; }
        public string HighPrice { get; set; }
        public string LowPrice { get; set; }
        public string Created { get; set; }
        public string ChangeFromPrevious { get; set; }
    }
}
