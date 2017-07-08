using System;
using System.Collections.Generic;
using System.Text;

namespace StockService
{
    public class TimeSeriesDaily
    {
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public int Volume { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public string DayString { get; set; }
    }

}
