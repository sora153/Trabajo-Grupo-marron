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
        
        private readonly  MotorcycleSpecsDatabase _client;
        private readonly   MotorcycleSpecsDatabase _request;
        private object client;

        public MotosApiController(ILogger<MotosApiController> logger,
        MotorcycleSpecsDatabase client,MotorcycleSpecsDatabase request)
        {
            _logger = logger;
            _client=client;
            _request=request;
        }

        public IActionResult Index()
        {
            return View();
        }

        public object GetClient()
        {
            return client;
        }

        [HttpPost]
        public async Task<IActionResult> Exchange(MotosApiDTO? , object client)
        {
           using (var response = await client.SendAsync(request))
{
	    response.EnsureSuccessStatusCode();
	    var body = await response.Content.ReadAsStringAsync();
	    Console.WriteLine(body);
}
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

    
}