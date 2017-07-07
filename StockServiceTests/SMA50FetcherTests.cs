using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockService;

namespace StockServiceTests
{
    [TestClass]
    public class SMA50FetcherTests
    {
        [TestMethod]
        public void TestFetchServiceData()
        {
            var stockServce = new SMA50Fetcher("PIZZA.HE");
            var json = stockServce.FetchData().Result;
            Assert.IsNotNull(json);

            var result = stockServce.ReplaceValues(json);

            var value = stockServce.GetValue(result, "$.MetaData.Symbol");
            Assert.AreEqual("PIZZA.HE", value);
        }

        [TestMethod]
        public void TestParseData()
        {
            var stockServce = new SMA50Fetcher("PIZZA.HE");
            var json = @"{
                'Meta Data': {
                    '1: Symbol': 'PIZZA.HE',
                    '2: Indicator': 'Simple Moving Average (SMA)',
                    '3: Last Refreshed': '2017-07-06',
                    '4: Interval': 'daily',
                    '5: Time Period': 50,
                    '6: Series Type': 'close',
                    '7: Time Zone': 'US/Eastern'
                },
                'Technical Analysis: SMA': {
                    '2017-07-06': {
                        'SMA': '13.4486'
                    },
                    '2017-07-05': {
                        'SMA': '13.4004'
                    },
                    '2017-05-02': {
                        'SMA': '11.2978'
                    }
                }
            }";

            var result = stockServce.ReplaceValues(json);

            var value = stockServce.GetValue(result, "$.TechnicalAnalysis.2017-07-06.SMA");
            Assert.AreEqual("13.4486", value);
        }

        [TestMethod]
        public void TestGetSMA50AtGivenDay()
        {
            var stockServce = new SMA50Fetcher("PIZZA.HE");
            var val = stockServce.GetSMA50AtDay(DateTime.Parse("2017-07-06")).Result;
            Assert.AreEqual(13.4486M, val);
        }

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
