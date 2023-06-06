using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trabajo.DTO;
using Trabajo.Integration;

namespace Trabajo.Controllers
{
    public class MotosApiController : Controller
    {
        private readonly ILogger<MotosApiController> _logger;
        private readonly CurrencyExchangeApiIntegration _currency;

        public MotosApiController(ILogger<MotosApiController> logger,
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