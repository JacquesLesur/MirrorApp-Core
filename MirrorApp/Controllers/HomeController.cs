using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirrorApp.Models;
using MMirrorApp.Models;
using Newtonsoft.Json;
using System.IO;

namespace MirrorApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.kaamelott = Kaamelott();
            Config.citation = ViewBag.kaamelott;
            ViewBag.weather = Weather();
            ViewBag.news = News().articles;
            ViewBag.youtubeUrl = Config.youtubeUrl;
            return View();
        }
        private NewsApi News()
        {
            string bodyResp = ApiCall(Config.newsUrl.concat());
            if (!String.IsNullOrEmpty(bodyResp))
            {
                return JsonConvert.DeserializeObject<NewsApi>(bodyResp);
                

            }
            else
            {
                return new NewsApi();
            }

        }

        
        private List<string> Weather()
        {
            List<string> returnStrings = new List<string>();
            string bodyResp = ApiCall(Config.wetherUrl.concat());
            WeatherApi weatherResponse = JsonConvert.DeserializeObject<WeatherApi>(bodyResp);
            returnStrings.Add(weatherResponse.weather.First().description.ToUpper());
            returnStrings.Add( weatherResponse.main.temp.ToString() + "°");
            string imagesFolder = @"~/images/Weather/";
            string pathLogo =  imagesFolder + weatherResponse.weather.First().description + ".png";
            if (System.IO.File.Exists(pathLogo))
            {
                returnStrings.Add(pathLogo);
            }
            else if (returnStrings.First().Contains("PLUIE"))
            {
                returnStrings.Add(@"/images/Weather/pluie.png");
            }
            else
            {
                returnStrings.Add(@"/images/Weather/couvert.png");
            }
            return returnStrings;
        }
        public string Kaamelott()
        {

            // Parse the response body.
            string bodyResp = ApiCall(Config.kaamelottUrl);
            KaamelottResponse kaamResp = JsonConvert.DeserializeObject<KaamelottResponse>(bodyResp);
            return kaamResp.Citation.citation + "\n" + kaamResp.Citation.infos.personnage + " - " + kaamResp.Citation.infos.saison;


        }
        private static string ApiCall(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                return response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }
            else
            {
                return null;
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
