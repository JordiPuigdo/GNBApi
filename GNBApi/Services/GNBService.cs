using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GNBApi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GNBApi.Services
{
    public class GNBService : IGNBService
    {
        private const string Host = "https://localhost:7118/transactions";
        private List<Rate> rates = new List<Rate>();

        public async Task<List<Transaction>> GetAllTransactions(string name)
        {
            var jsonString = await getJsonString(name);
            return JsonConvert.DeserializeObject<List<Transaction>>(jsonString);
        }

        public async Task<List<Rate>> GetAllRates(string name)
        {
            var jsonString = await getJsonString(name);
            rates = JsonConvert.DeserializeObject<List<Rate>>(jsonString);
            return rates;
        }

        private async Task<string> getJsonString(string name)
        {
            var response = await GetHttpClient().GetAsync($"{Host}/{name}");
            return await response.Content.ReadAsStringAsync();
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Awesome Octocat App");

            return httpClient;
        }

        public async Task<List<Transaction>> GetSKUTransactions(string name, string SKU)
        {
            try
            {
                if(rates.Count == 0)
                {
                    GetAllRates("GetRates");
                }

                List<Transaction> transactions = new List<Transaction>();
                var jsonString = await getJsonString(name);
                var transactionsList = JsonConvert.DeserializeObject<List<Transaction>>(jsonString);

                foreach(var item in transactionsList)
                {
                    if (item.sku == SKU)
                    {
                        if (item.currency != "EUR")
                        {
                            item.amount = ConvertToEuro(item.amount, item.currency);
                        }
                        transactions.Add(item);
                    }
                }
                
                return transactions;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private string ConvertToEuro(string quantity, string currencyOrigin)
        {
            decimal qtty;
            switch (currencyOrigin)
            {
                case "USD":
                    var conversion = rates.Find(c => (c.destiny == "EUR" && c.origin == "USD"));
                    qtty = Convert.ToDecimal(quantity, new CultureInfo("en-US")) * Convert.ToDecimal(conversion.rate, new CultureInfo("en-US"));
                    return Convert.ToString(qtty);
                    break;
            }


            return "";
        }

        private static bool canConvert()
        {

            return true;
        }
    }
}
