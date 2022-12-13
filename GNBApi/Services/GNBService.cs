using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GNBApi.Model;
using Newtonsoft.Json;

namespace GNBApi.Services
{
    public class GNBService : IGNBService
    {
        private const string Host = "https://localhost:7118/skucontroller";


        public async Task<List<Transaction>> GetAllTransactions(string name)
        {
            var response = await GetHttpClient().GetAsync($"{Host}");
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Transaction>>(jsonString);
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Awesome Octocat App");

            return httpClient;
        }
    }
}
