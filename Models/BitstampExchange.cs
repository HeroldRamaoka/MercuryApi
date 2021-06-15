using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercuryApi.Models
{
    public class BitstampExchange
    {
        public string High { get; set; }
        public string Last { get; set; }
        public string TimeStamp { get; set; }
        public string Bid { get; set; }
        public string Vwap { get; set; }
        public string Volume { get; set; }
        public string Low { get; set; }
        public string Ask { get; set; }
        public string Open { get; set; }

    }
}
