using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockService;

namespace StockServiceTests
{
    [TestClass]
    class TimeSeriesDailyFetcherTests
    {
        [TestMethod]
        public void TestFetchTimeSeriesServiceData()
        {
            var stockServce = new TimeSeriesDailyFetcher("PIZZA.HE");
            var json = stockServce.FetchData().Result;
            Assert.IsNotNull(json);

            var result = stockServce.ReplaceValues(json);

            var value = stockServce.GetValue(result, "$.MetaData.Symbol");
            Assert.AreEqual("PIZZA.HE", value);
        }
    }
}
