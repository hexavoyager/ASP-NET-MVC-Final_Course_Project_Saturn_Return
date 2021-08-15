#region USING
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SR_BLL.Services;
using SR_DAL.Data;
using SR_DAL.Repos;
using SR_MVC.Infrastructure.Session;
using SR_MVC.Models;
using SR_MVC.Models.APIs;
using SR_MVC.Models.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
#endregion

namespace SR_MVC.Controllers
{
    public class HomeController : Controller
    {
        #region Local tools
        private readonly ILogger<HomeController> _logger;
        private readonly IPlanetRepo _planetRepo;
        private readonly IBookingRepo _bookingRepo;
        private readonly IClientRepo _clientRepo;
        private readonly ISessionManager _sessionManager;

        public HomeController(ILogger<HomeController> logger, IPlanetRepo planetRepo, IBookingRepo bookingRepo, IClientRepo clientRepo, ISessionManager sessionManager)
        {
            _logger = logger;
            _planetRepo = planetRepo;
            _bookingRepo = bookingRepo;
            _clientRepo = clientRepo;
            _sessionManager = sessionManager;
        }
        #endregion
        public IActionResult Booking()
        {
            if (_sessionManager.Client != null)
            {
                HomeForm form = new HomeForm();
                form.Planets = GetPlanets();
                return View(form);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Booking(HomeForm form)
        {
            #region Weather API Call
            HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.weather.gov/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "ForecastAPI");
                HttpResponseMessage httpResponseMessage = client.GetAsync("gridpoints/LWX/81,50/forecast").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                JsonDocument jsonDocument = JsonDocument.Parse(json);
                JsonElement rootElement = jsonDocument.RootElement;
                JsonElement properties = rootElement.GetProperty("properties");
                JsonElement periods = properties.GetProperty("periods");
                IEnumerable<Period> periodsResult = System.Text.Json.JsonSerializer.Deserialize<Period[]>(periods.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            #endregion

            if (!ModelState.IsValid)
            {
                form.Planets = GetPlanets();
                return View(form);
            }

            #region Date & Wind checks
            IEnumerable<Period> selectedDates;
            DateTime pickedDate = form.dateA.Date;
            string[] stringWeatherDates = periodsResult.Select(p => p.StartTime.ToString("MM/dd/yyyy")).ToArray();

            foreach (Period p in periodsResult)
            {
                string weatherDateString = p.StartTime.Date.ToString("MM/dd/yyyy");
                string pickedDateString = pickedDate.ToString("MM/dd/yyyy");
                bool dateInRange = stringWeatherDates.Contains(pickedDateString);

                if (dateInRange)
                {
                    selectedDates = periodsResult.Where(x =>
            x.StartTime.Date == pickedDate);

                    int datesCount = selectedDates.Count();
                    Period date1 = selectedDates.ElementAt(0);
                    Period date2 = datesCount > 1 ? selectedDates.ElementAt(1) : date1;

                    DateTime today = DateTime.Now;

                    string cleanWindSpeed1 = new string(date1.WindSpeed.Where(Char.IsDigit).ToArray());

                    if (cleanWindSpeed1.Length > 1)
                    {
                        cleanWindSpeed1 = cleanWindSpeed1.Substring(1);
                    }
                    int intWindSpeed1 = Int32.Parse(cleanWindSpeed1);

                    string cleanWindSpeed2 = new string(date2.WindSpeed.Where(Char.IsDigit).ToArray());

                    if (cleanWindSpeed2.Length > 1)
                    {
                        cleanWindSpeed2 = cleanWindSpeed2.Substring(1);
                    }
                    int intWindSpeed2 = Int32.Parse(cleanWindSpeed2);


                    #endregion
                    ViewBag.Alert = "";

                    if (intWindSpeed1 < 7 && intWindSpeed2 < 7)
                    {
                        Booking b = new Booking()
                        {
                            clientId = _sessionManager.Client.Id,
                            planet = form.planet,
                            stopover = form.stopover,
                            planet_portId = 15,
                            dateA = form.dateA,
                            dateB = form.dateB,
                            is_1stclass = form.is_1stclass,
                            price = 100
                        };

                        _bookingRepo.Create(b.clientId, b.planet, b.stopover, b.planet_portId, b.dateA, b.dateA, b.is_1stclass, b.price);

                        _clientRepo.UpdateCount(_sessionManager.Client.Id, _sessionManager.Client.Book_count + 1);
                        //break;

                    }
                    else if (date1.StartTime == today | date2.StartTime == today)

                    {
                        ViewBag.Alert = "todayErr";
                        return View(form);

                    }
                    else
                    {
                        ViewBag.Alert = "weatherErr";
                        return View(form);
                    }

                } else
                {
                    Booking b = new Booking()
                    {
                        clientId = _sessionManager.Client.Id,
                        planet = form.planet,
                        stopover = form.stopover,
                        planet_portId = 15,
                        dateA = form.dateA,
                        dateB = form.dateB,
                        is_1stclass = form.is_1stclass,
                        price = 100
                    };

                    _bookingRepo.Create(b.clientId, b.planet, b.stopover, b.planet_portId, b.dateA, b.dateA, b.is_1stclass, b.price);

                    _clientRepo.UpdateCount(_sessionManager.Client.Id, _sessionManager.Client.Book_count + 1);

                    break;
                }
                
            }

            return RedirectToAction("Logged", "Auth");
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private IEnumerable<SelectListItem> GetPlanets(int? id = null)
        {
            return _planetRepo.Get().Select(c => new SelectListItem(c.name, c.id.ToString()) { Selected = (id.HasValue && c.id == id.Value) });
        }


        public IActionResult GetPlanetInfo(int id)
        {

            Planet p = _planetRepo.Get(id);
            DisplayPlanet dp = new DisplayPlanet()
            {
                Name = p.name,
                Atmosphere = p.atmosphere,
                Distance_m = p.distance_m,
                Distance_h = p.distance_h,
                Ports_count = p.ports_count
            };

            return PartialView("_atmosphere", dp);
        }

        public IActionResult Planets()
        {
            IEnumerable<Planet> Planets = _planetRepo.Get().ToList();

            return View(Planets.Select(p => new DisplayPlanet()
            {
                Name = p.name,
                Atmosphere = p.atmosphere,
                Distance_m = p.distance_m,
                Distance_h = p.distance_h,
                Ports_count = p.ports_count
            }));
            
        }


        public IActionResult Weather()
        {
            #region Weather API Call
            //"https://api.weather.gov/gridpoints/LWX/81,50/forecast"
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.weather.gov/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("User-Agent", "ForecastAPI");
                HttpResponseMessage httpResponseMessage = client.GetAsync("gridpoints/LWX/81,50/forecast").Result;
                httpResponseMessage.EnsureSuccessStatusCode();
                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                JsonDocument jsonDocument = JsonDocument.Parse(json);
                JsonElement rootElement = jsonDocument.RootElement;
                JsonElement properties = rootElement.GetProperty("properties");
                JsonElement periods = properties.GetProperty("periods");
                IEnumerable<Period> periodsResult = System.Text.Json.JsonSerializer.Deserialize<Period[]>(periods.ToString(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return View(periodsResult);
            }
            #endregion
        }


    }
}
