using System;
using System.Collections.Generic;
using System.Text;

namespace StockService
{
    public class TimeSeriesDaily
    {
        public TimeSeriesMetaData TimeSeriesMetaData { get; set; }
        public List<TimeSeriesEntry> TimeSeriesEntries { get; set; }
    }

    public class TimeSeriesMetaData
    {
        public Dictionary<string, string> Entries { get; set; }
    }

    public class TimeSeriesEntry
    {
        public DateTime Date { get; set; }
        public Dictionary<string, string> Entries { get; set; }
    }
}
