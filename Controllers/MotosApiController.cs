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
         static async Task Main(string[] args){
            string apiKey = "89808bcf44mshc2b67244f0dfe73p1342b3jsn471f934c3e23";
        string baseUrl = "https://motorcycle-specs-database.p.rapidapi.com/article";
            
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("X-RapidAPI-Key", apiKey);

            try{
                 HttpResponseMessage response = await client.GetAsync(baseUrl + "/2012/BMW/F%20800%20GS%20Trophy");

                 if (response.IsSuccessStatusCode){
                    
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                   MotorcycleSpecsData data = JsonConvert.DeserializeObject<MotorcycleSpecsData>(jsonResponse);


                Console.WriteLine($"Modelo: {data.Model}");
                Console.WriteLine($"Fabricante: {data.Make}");
                Console.WriteLine($"Año: {data.Year}");
                Console.WriteLine($"Especificaciones: {data.Specs}");



                 }else{

                    Console.WriteLine($"Error en la solicitud: {response.StatusCode}");
                 }
            }
            catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            
            client.Dispose();
        }

         }
       
    }

    class MotorcycleSpecsData
{
    public string? Model { get; set; }
    public string? Make { get; set; }
    public int Year { get; set; }
    public string? Specs { get; set; }
}
}