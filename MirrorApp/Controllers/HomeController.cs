using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MirrorApp.Models;
using Newtonsoft.Json;

namespace MirrorApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.kaamelott = Kaamelott();
            return View();
        }
        //private void News()
        //{
        //    string bodyResp = ApiCall(Config.newsUrl.concat());
        //    if (!String.IsNullOrEmpty(bodyResp))
        //    {
        //        NewsApi newsResponse = JsonConvert.DeserializeObject<NewsApi>(bodyResp);
        //        lNews.ItemsSource = newsResponse.articles;

        //    }

        //}

        //private void Date()
        //{
        //    var date = DateTime.Now;
        //    lHour.Text = date.Hour.ToString() + "h" + date.Minute.ToString();
        //}
        //private void Weather()
        //{
        //    string bodyResp = ApiCall(Config.wetherUrl.concat());
        //    WeatherApi weatherResponse = JsonConvert.DeserializeObject<WeatherApi>(bodyResp);
        //    lWeather.Text = weatherResponse.weather.First().description.ToUpper();
        //    lTemp.Text = weatherResponse.main.temp.ToString() + "°";
        //    string imagesFolder = @"\Assets\Images\Weather\";
        //    StorageFolder InstallationFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
        //    string pathLogo = InstallationFolder.Path + imagesFolder + lWeather.Text + ".png";
        //    if (File.Exists(pathLogo))
        //    {
        //        iWeather.Source = new BitmapImage(new Uri(pathLogo));
        //    }
        //    else
        //    {
        //        string test = InstallationFolder.Path + imagesFolder + "ensoleiller.png";
        //        iWeather.Source = new BitmapImage(new Uri(InstallationFolder.Path + imagesFolder + "ensoleiller.png"));
        //    }

        //}
        private string Kaamelott()
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
