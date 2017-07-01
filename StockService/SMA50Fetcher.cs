using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace StockService
{
    public class SMA50Fetcher : DataFetcher
    {
        
        public SMA50Fetcher()
        {
            this.Arguments = "function=SMA&symbol=PIZZA.HE&interval=daily&time_period=50&series_type=close";
        }
    }

    
    public class DataFormat
    {

    }

    public class StockEntry
    {
    }
}
