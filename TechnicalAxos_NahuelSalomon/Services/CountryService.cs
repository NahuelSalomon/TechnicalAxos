using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos_NahuelSalomon.Models;

namespace TechnicalAxos_NahuelSalomon.Services
{
    public class CountryService
    {
        private static readonly HttpClient _client = new HttpClient();

        public async Task<List<Country>> GetAllAsync()
        {
            var response = await _client.GetStringAsync("https://restcountries.com/v3.1/all");
            var countries = JsonConvert.DeserializeObject<List<Country>>(response);
            return countries!;
        }
    }
}
