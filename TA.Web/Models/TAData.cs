using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TA.Web.Models
{
    public class TAData
    {
        public string Ticker { get; set; }
        public decimal TAValue { get; set; }
        public decimal LastClose { get; set; }
        public decimal DiffVsCurrentPrice { get; set; }
        public string Day { get; set; }
        public string TAType { get; set; }
    }
}
