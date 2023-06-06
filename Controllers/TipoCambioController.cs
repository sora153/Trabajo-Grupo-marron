using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trabajo.DTO;
using Trabajo.Integration;
using System.Net.Http.Headers;

namespace Trabajo.Controllers
{
    public class TipoCambioController : Controller
    {
        private readonly ILogger<TipoCambioController> _logger;
        private readonly CurrencyExchangeApiIntegration _currency;

        public TipoCambioController(ILogger<TipoCambioController> logger,
        CurrencyExchangeApiIntegration currency)
        {
            _logger = logger;
            _currency = currency;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Exchange(TipoCambioDTO? tipoCambio)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
	        Method = HttpMethod.Get,
	        RequestUri = new Uri("https://motorcycle-specs-database.p.rapidapi.com/article/2012/BMW/F%20800%20GS%20Trophy"),
	        Headers =
	            {
		        { "X-RapidAPI-Key", "89808bcf44mshc2b67244f0dfe73p1342b3jsn471f934c3e23" },
		        { "X-RapidAPI-Host", "motorcycle-specs-database.p.rapidapi.com" },
	            },
            };
            using (var response = await client.SendAsync(request))
            {
	            response.EnsureSuccessStatusCode();
	            var body = await response.Content.ReadAsStringAsync();
	            Console.WriteLine(body);
            }
           double rate = await _currency.GetExchangeRate(tipoCambio.From, tipoCambio.To);
           var cambio = tipoCambio.Cantidad * rate;
           ViewData["rate"] = rate;
           ViewData["cambio"] = cambio;
           return View("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}