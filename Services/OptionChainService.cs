using ContosoPets.Ui.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ContosoPets.Ui.Services
{
    public class OptionChainService
    {
        private readonly string _route;
        private readonly HttpClient _httpClient;

        public OptionChainService(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _route = configuration["OptionChainService:ControllerRoute"];
        }

        static string BaseAddress = "https://api.tdameritrade.com";
        static string ApiKey = "LHZELHONT2CCYJ33EBLWPMIBADA1FTVR";   //set this to your apikey, or put your api key in the first line of file AuthData.txt"
        // returns the option chain data for a stock symbol into
        //more info at https://developer.tdameritrade.com/option-chains/apis/get/marketdata/chains#
        //strikeCount=1

        public async Task<IEnumerable<OptionChain>> GetOptionChains()
        {
            var response = await _httpClient.GetAsync(_route);
            response.EnsureSuccessStatusCode();

            var optionChains = await response.Content.ReadAsAsync<IEnumerable<OptionChain>>();

            return optionChains;
        }

        public async Task<OptionChain> GetOptionChainBySymbol(string symbol)
        {
            var response = await _httpClient.GetAsync($"{_route}/{symbol}");
            response.EnsureSuccessStatusCode();

            var optionChain = await response.Content.ReadAsAsync<OptionChain>();

            return optionChain;
        }

   

        private void ensureAuthorization()
        {
            if (ApiKey == null)
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), @".\AuthData.txt"));
                    if (lines.Length > 0)
                        ApiKey = System.Web.HttpUtility.UrlEncode(lines[0]);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        async Task<HttpResponseMessage> getResponse(string RequestUri)
        {
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Add("User-Agent", "Anything");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync(RequestUri);
                    response.EnsureSuccessStatusCode();
                }
                catch (Exception e)
                {
                    //string sz = $"ERROR: {e.Message} " + e?.InnerException.Message;
                    throw (e);

                }
                return response;

            }
        }

        public async Task<List<string>> getOptionDates(string symbol)
        {
            if (symbol == null || symbol == "")
                return null;
            HttpResponseMessage response;
            ensureAuthorization();
            string RequestUri = $"/v1/marketdata/chains?apikey={ApiKey}&symbol={symbol}&contractType=PUT&strikeCount=1";
            try
            {
                response = await getResponse(RequestUri);
            }
            catch
            {
                return null;
            }
            string result = await response.Content.ReadAsStringAsync();
            var ochain = response.Content.ReadAsAsync<OptionChain>().Result;
            var optionDates = new List<string>();
            foreach (var item in ochain.putExpDateMap)
            {
                optionDates.Add(item.Key.Remove(item.Key.LastIndexOf(':')));

            }
            return optionDates;

        }

        public async Task<OptionChain> GetOptionChain(string symbol, string contractType)
        {
            if (symbol == null || symbol == "")
                return null;
            HttpResponseMessage response;
            ensureAuthorization();

            string RequestUri = $"/v1/marketdata/chains?apikey={ApiKey}&symbol={symbol}&contractType={contractType}&includeQuotes=TRUE&strikeCount=40";
            try
            {
                response = await getResponse(RequestUri);
            }
            catch
            {
                return null;
            }
            string result = await response.Content.ReadAsStringAsync();
            var ochain = response.Content.ReadAsAsync<OptionChain>().Result;
            return ochain;

        }
    }
}