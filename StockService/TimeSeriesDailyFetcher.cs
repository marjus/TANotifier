using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace StockService
{
    public class TimeSeriesDailyFetcher : DataFetcher
    {
        const string jpath = "$.TimeSeries.{day}.{type}";

        public TimeSeriesDailyFetcher(string symbol)
        {
            Arguments = $"function=TIME_SERIES_DAILY&symbol={symbol}";

            ReplaceStrings.Clear();
            ReplaceStrings.Add("Time Series (Daily)", "TimeSeries");
            ReplaceStrings.Add("Meta Data", "MetaData");
            ReplaceStrings.Add("1. open", "Open");
            ReplaceStrings.Add("2. Symbol", "Symbol");
            ReplaceStrings.Add("2. high", "High");
            ReplaceStrings.Add("3. low", "Low");
            ReplaceStrings.Add("4. close", "Close");
            ReplaceStrings.Add("5. volume", "Volume");            
        }

        public async Task<TimeSeriesDaily> GetDayValue(DateTime day)
        {
            var json = await FetchData();
            var validJson = ReplaceValues(json);
            var daystring = day.ToString("yyyy-MM-dd");
            var fulljpath = jpath.Replace("{day}", daystring);
            fulljpath = fulljpath.Replace("{type}", "Close");
            var value = GetValue(validJson, fulljpath);

            if (string.IsNullOrEmpty(value))
            {
                throw new JsonException("Result empty");
            }
            var timeEntry = new TimeSeriesDaily()
            {
                Close = decimal.Parse(value, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture),
                DayString = daystring
            };
            return timeEntry;
        }
    }
}
