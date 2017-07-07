using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StockService
{
    public abstract  class DataFetcher
    {
        const string ApiKey = "&apikey=JMVK0ST2FGOQ9A8W";
        const string ServiceUrl = "https://www.alphavantage.co/query?";
        protected string Arguments = "";
        protected Dictionary<string, string> ReplaceStrings = new Dictionary<string, string>();

        public string ReplaceValues(string input)
        {
            foreach(var rs in ReplaceStrings)
            {
                input = input.Replace(rs.Key, rs.Value);
            }
            return input;
        }

        public async Task<string> FetchData()
        {
            string url = ServiceUrl + Arguments + ApiKey;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                WebResponse response = await request.GetResponseAsync();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                    // log errorText
                }
                throw;
            }
        }

        public string GetValue(string json, string key)
        {
            var result = JObject.Parse(json);
            return result.SelectToken(key).ToString();
        }
    }
}
