using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Globalization;

namespace StockService
{
    public class SMA50Fetcher : DataFetcher
    {
        const string jpath = "$.TechnicalAnalysis.{0}.SMA";

        public SMA50Fetcher(string symbol)
        {
            Arguments = $"function=SMA&symbol={symbol}&interval=daily&time_period=50&series_type=close";

            ReplaceStrings.Clear();
            ReplaceStrings.Add("Technical Analysis: SMA", "TechnicalAnalysis");
            ReplaceStrings.Add("Meta Data", "MetaData");
            ReplaceStrings.Add("1: Symbol", "Symbol");
            
        }

        public async Task<decimal> GetSMA50AtDay(DateTime day)
        {            
            var json = await FetchData();
            var validJson = ReplaceValues(json);
            var daystring = day.ToString("yyyy-MM-dd");
            var fulljpath = jpath.Replace("{0}", daystring);
            var value = GetValue(validJson, fulljpath);

            if(string.IsNullOrEmpty(value))
            {
                throw new JsonException("Result empty");
            }
            return decimal.Parse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture);
        }
    }

}
