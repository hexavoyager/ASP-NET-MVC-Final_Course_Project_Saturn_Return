using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SR_DAL.Data;
using SR_DAL.Repos;
using SR_MVC.Infrastructure.Session;
using SR_MVC.Models;
using SR_MVC.Models.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlanetRepo _planetRepo;
        private readonly IBookingRepo _bookingRepo;
        private readonly ISessionManager _sessionManager;
        public HomeController(ILogger<HomeController> logger, IPlanetRepo planetRepo, IBookingRepo bookingRepo, ISessionManager sessionManager)
        {
            _logger = logger;
            _planetRepo = planetRepo;
            _bookingRepo = bookingRepo;
            _sessionManager = sessionManager;
        }
        public IActionResult Booking()
        {
            HomeForm form = new HomeForm();
            form.Planets = GetPlanets();
            return View(form);
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

        [HttpPost]

        public IActionResult Booking(HomeForm form)
        {
            if (!ModelState.IsValid)
            {
                form.Planets = GetPlanets();
                return View(form);
            }

            Booking b = new Booking()
            {
                clientId = _sessionManager.Client.Id,
                planet = true,
                stopover = form.Stopover,
                planet_portId = 15,
                dateA = form.DateA,
                dateB = form.DateB,
                is_1stclass = form.Is_1stclass,
                price = 100
            };

            _bookingRepo.Create(b.clientId, b.planet, b.stopover, b.planet_portId, b.dateA, b.dateA, b.is_1stclass, b.price);

            return RedirectToAction("Index");
        }


    }
}
