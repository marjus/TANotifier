using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockService;

namespace TA.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            var ticker = "PIZZA.HE";
            var smaService = new SMA50Fetcher(ticker);

            var tsService = new TimeSeriesDailyFetcher(ticker);
            var sma50 = await smaService.GetSMA50AtDay(DateTime.Now);

            var ts = await tsService.GetDayValue(DateTime.Now);

            ViewData["Message"] = $"{ticker} SMA50: {sma50} Close value: {ts.Close}";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
