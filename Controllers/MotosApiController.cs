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
                        { "X-RapidAPI-Key", "42c5f6dff9mshbc3ef692c04d3aep1d196ajsn4948f93fed7f" },
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
                        { "X-RapidAPI-Key", "42c5f6dff9mshbc3ef692c04d3aep1d196ajsn4948f93fed7f" },
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
        var articleInfo = item.articleCompleteInfo;
        var engineInfo = item.engineAndTransmission;
        var chassisInfo = item.chassisSuspensionBrakesAndWheels;
        var measuresInfo = item.physicalMeasuresAndCapacities;
        var otherInfo = item.otherSpecifications;

        var moto = new MotosApiDTO3
        {
            ArticleCompleteInfo = new ArticleCompleteInfo
            {
                ArticleID = articleInfo.articleID,
                MakeName = articleInfo.makeName,
                ModelName = articleInfo.modelName,
                CategoryName = articleInfo.categoryName,
                YearName = articleInfo.yearName
            },
            EngineAndTransmission = new EngineAndTransmission
            {
                DisplacementName = engineInfo.displacementName,
                EngineTypeName = engineInfo.engineTypeName,
                EngineDetailsName = engineInfo.engineDetailsName,
                PowerName = engineInfo.powerName,
                TorqueName = engineInfo.torqueName,
                CompressionName = engineInfo.compressionName,
                BoreXStrokeName = engineInfo.boreXStrokeName,
                ValvesPerCylinderName = engineInfo.valvesPerCylinderName,
                FuelSystemName = engineInfo.fuelSystemName,
                LubricationSystemName = engineInfo.lubricationSystemName,
                CoolingSystemName = engineInfo.coolingSystemName,
                GearboxName = engineInfo.gearboxName,
                TransmissionTypeFinalDriveName = engineInfo.transmissionTypeFinalDriveName,
                ClutchName = engineInfo.clutchName,
                DrivelineName = engineInfo.drivelineName,
                ExhaustSystemName = engineInfo.exhaustSystemName
            },
            ChassisSuspensionBrakesAndWheels = new ChassisSuspensionBrakesAndWheels
            {
                FrameTypeName = chassisInfo.frameTypeName,
                FrontBrakesName = chassisInfo.frontBrakesName,
                FrontBrakesDiameterName = chassisInfo.frontBrakesDiameterName,
                FrontSuspensionName = chassisInfo.frontSuspensionName,
                FrontTyreName = chassisInfo.frontTyreName,
                FrontWheelTravelName = chassisInfo.frontWheelTravelName,
                RakeName = chassisInfo.rakeName,
                RearBrakesName = chassisInfo.rearBrakesName,
                RearBrakesDiameterName = chassisInfo.rearBrakesDiameterName,
                RearSuspensionName = chassisInfo.rearSuspensionName,
                RearTyreName = chassisInfo.rearTyreName,
                RearWheelTravelName = chassisInfo.rearWheelTravelName,
                TrailName = chassisInfo.trailName
            },
            PhysicalMeasuresAndCapacities = new PhysicalMeasuresAndCapacities
            {
                DryWeightName = measuresInfo.dryWeightName,
                FuelCapacityName = measuresInfo.fuelCapacityName,
                OverallHeightName = measuresInfo.overallHeightName,
                OverallLengthName = measuresInfo.overallLengthName,
                OverallWidthName = measuresInfo.overallWidthName,
                PowerWeightRatioName = measuresInfo.powerWeightRatioName,
                ReserveFuelCapacityName = measuresInfo.reserveFuelCapacityName,
                SeatHeightName = measuresInfo.seatHeightName
            },
            OtherSpecifications = new OtherSpecifications
            {
                ColorOptionsName = otherInfo.colorOptionsName,
                CommentsName = otherInfo.commentsName
            }
        };

        spec.Add(moto);
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
                        { "X-RapidAPI-Key", "42c5f6dff9mshbc3ef692c04d3aep1d196ajsn4948f93fed7f" },
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
                        { "X-RapidAPI-Key", "42c5f6dff9mshbc3ef692c04d3aep1d196ajsn4948f93fed7f" },
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