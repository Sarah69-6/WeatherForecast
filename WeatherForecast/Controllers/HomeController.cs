using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    
        public ActionResult Index()
          {

            return View();
        }


        string Baseurl = "https://www.metaweather.com/";
        public async Task<ActionResult> WeatherPage()
        {
            List<Weather> weathers = new List<Weather>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage message = await client.GetAsync("/api/location/44544/2020/7/14/");

                if (message.IsSuccessStatusCode)
                {
                    var WeatherResponse = message.Content.ReadAsStringAsync().Result;
                    weathers = JsonConvert.DeserializeObject<List<Weather>>(WeatherResponse);
                }
            }
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Image/svg"));
                HttpResponseMessage message = await client.GetAsync("/static/img/weather/s.svg");

                if (message.IsSuccessStatusCode)
                {
                    message.Content.Headers.ContentType = new MediaTypeHeaderValue("Image/svg");
                }
                return View(weathers);
            }
        }

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
