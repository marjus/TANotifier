using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockService;

namespace TA.Web.Controllers
{
    public class TAController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            var modelData = new List<Models.TAData>();

            var tickerList = new List<string>();
            
            tickerList.Add( "PIZZA.HE");
            tickerList.Add("CINN.ST");
            tickerList.Add("MYCR.ST");
            tickerList.Add("HMED.ST");
            tickerList.Add("CTM.ST");
            tickerList.Add("GEN.CO");
            tickerList.Add("ALIV-SDB.ST");

            tickerList.Add("TOBII.ST");
            tickerList.Add("VWS.CO");
            tickerList.Add("LIFCO-B.ST");
            tickerList.Add("HM-B.ST");
            tickerList.Add("BAKKA.OL");
            tickerList.Add("SAAB-B.ST");

            tickerList.Add("JNJ");
            tickerList.Add("O");
            tickerList.Add("MSFT");
            // tickerList.Add("LITI.ST");
            tickerList.Add("SOBI.ST");
            tickerList.Add("GIG.OL");
            tickerList.Add("EVO.ST");
            tickerList.Add("LEO.ST");

            foreach (var ticker in tickerList)
            {
                var smaService = new SMA50Fetcher(ticker);
                var date = DateTime.Now.AddDays(-1);

                var tsService = new TimeSeriesDailyFetcher(ticker);
                var sma50 = await smaService.GetSMA50AtDay(date);

                var ts = await tsService.GetDayValue(date);
                
                var tadata = new Models.TAData();

                tadata.Day = ts.DayString;
                tadata.Ticker = ticker;
                tadata.TAValue = sma50;
                tadata.TAType = "SMA50";
                tadata.DiffVsCurrentPrice = Math.Round((ts.Close - sma50) * 100 / sma50, 1);
                tadata.LastClose = ts.Close;
                modelData.Add(tadata);
            }

            return View(modelData);
        }
    }
}