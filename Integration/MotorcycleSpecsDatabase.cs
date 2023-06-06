using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Trabajo.Integration
{
    public class MotorcycleSpecsDatabase
    {
         private readonly ILogger<MotorcycleSpecsDatabase> _logger;
         private const string API_URL="https://motorcycle-specs-database.p.rapidapi.com/article/2012/BMW/F%20800%20GS%20Trophy";
         private string API_KEY="89808bcf44mshc2b67244f0dfe73p1342b3jsn471f934c3e23";
         private string API_HEADER_KEY="X-RapidAPI-Key";

        private readonly HttpClient httpClient;

        public MotorcycleSpecsDatabase(ILogger<MotorcycleSpecsDatabase> logger){
            _logger = logger;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(API_HEADER_KEY, API_KEY);
        }

        public async Task<double> GetExchangeRate(string fromCurrency, string toCurrency){
            string requestUrl = $"{API_URL}?from={fromCurrency}&to={toCurrency}";
            try{
                HttpResponseMessage response = await httpClient.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    var result =  await response.Content.ReadAsStringAsync();
                    double exchangeRate = Convert.ToDouble(result);
                    return exchangeRate;
                }
            }catch(Exception ex){
                _logger.LogDebug($"Error al llamar a la API: {ex.Message}");
            }
            return 0;
        }

    }
}