using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trabajo.DTO;
using Trabajo.Integration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations.Schema;


namespace Trabajo.Controllers
{
    public class MotosApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ObtenerDatosDeAPI()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://motorcycle-specs-database.p.rapidapi.com/article/2012/BMW/F%20800%20GS%20Trophy"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "4caffe0f73msha769e2268018d23p14c5e1jsncc7bec4533f8" },
                        { "X-RapidAPI-Host", "motorcycle-specs-database.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    // Aquí puedes procesar los datos de la respuesta de la API
                    // Puedes almacenarlos en una variable para usarlos en tu vista o hacer cualquier otra operación con ellos

                    return Content(body);
                }
            }
        }

        public async Task<List<MotosApiDTO>> ObtenerMarcasDeMotos()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://motorcycle-specs-database.p.rapidapi.com/make"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "4caffe0f73msha769e2268018d23p14c5e1jsncc7bec4533f8" },
                        { "X-RapidAPI-Host", "motorcycle-specs-database.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    List<MotosApiDTO> marcas = ProcesarDatos(body);

                    return marcas;
                }
            }
        }

        private List<MotosApiDTO> ProcesarDatos(string responseBody)
        {
            dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
            List<MotosApiDTO> marcas = new List<MotosApiDTO>();

            foreach (var item in jsonResponse)
            {
                var marca = new MotosApiDTO
                {
                    Id = item.id,
                    Name = item.name
                };

                marcas.Add(marca);
            }

            return marcas;
        }

        private List<MotosApiDTO2> ProcesarDatos2(string responseBody)
        {
            dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
            List<MotosApiDTO2> modelos = new List<MotosApiDTO2>();

            foreach (var item in jsonResponse)
            {
                var modelos2 = new MotosApiDTO2
                {
                    Id = item.id,
                    Name = item.name
                };

                modelos.Add(modelos2);
            }

            return modelos;
        }

        private List<MotosApiDTO3> ProcesarDatos3(string responseBody)
        {
            dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
            List<MotosApiDTO3> spec = new List<MotosApiDTO3>();

            foreach (var item in jsonResponse)
            {
                var modelos3 = new MotosApiDTO3
                {
                    Id = item.id,
                    Name = item.name
                };

                spec.Add(modelos3);
            }

            return spec;
        }

        public async Task<List<MotosApiDTO2>> ObtenerModelosDeMotos(string marca)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://motorcycle-specs-database.p.rapidapi.com/model/make-id/{marca}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "4caffe0f73msha769e2268018d23p14c5e1jsncc7bec4533f8" },
                        { "X-RapidAPI-Host", "motorcycle-specs-database.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    List<MotosApiDTO2> modelos = ProcesarDatos2(body);

                    return modelos;
                }
            }
        }

        public async Task<List<MotosApiDTO3>> ObtenerSpecDeMotos(string marca, string modelo)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://motorcycle-specs-database.p.rapidapi.com/make/{marca}/model/{modelo}"),
                    Headers =
                    {
                        { "X-RapidAPI-Key", "4caffe0f73msha769e2268018d23p14c5e1jsncc7bec4533f8" },
                        { "X-RapidAPI-Host", "motorcycle-specs-database.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();

                    List<MotosApiDTO3> spec = ProcesarDatos3(body);

                    return spec;
                }
            }
        }
       
    }
}