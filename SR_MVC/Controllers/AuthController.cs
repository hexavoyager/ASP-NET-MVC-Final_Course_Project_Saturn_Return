using Microsoft.AspNetCore.Mvc;
using SR_BLL.Data;
using SR_BLL.Repos;
using SR_MVC.Infrastructure.Security;
using SR_MVC.Infrastructure.Session;
using SR_MVC.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SR_MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IClientRepo _clientRepo;
        private readonly ISessionManager _sessionManager;
        public AuthController(IClientRepo clientRepo, ISessionManager sessionManager)
        {
            _clientRepo = clientRepo;
            _sessionManager = sessionManager;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Client client = _clientRepo.Login(form.Email, form.Pass);

            if (client is null)
            {
                ModelState.AddModelError("", "Something's wrong...");
                return View(form);
            }

            _sessionManager.Client = new ClientSession()
            {
                Id = client.Id,
                LastName = client.lname,
                FirstName = client.fname,
                Bdate = client.bdate,
                Email = client.email,
                Ccard = client.ccard,
                Idcard = client.idcard,
                Book_count = client.book_count,
                Is_vip = client.is_vip,
                Is_healthy = client.is_healthy

            };

            return RedirectToAction("Logged");
        }

        [AnonymousRequired]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AnonymousRequired]
        public IActionResult Register(RegisterForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Client newClient = new Client(form.FirstName, form.LastName, form.Bdate, form.Email, form.Pass, form.CCard, form.IdCard, default, form.LastName.ToLower() == "bezos", true);

            _clientRepo.Register(newClient);

            return RedirectToAction("Login");
        }
        public IActionResult Logged()
        {
            Client CurrentClient = _clientRepo.Get(_sessionManager.Client.Id);
            string bookCountString = CurrentClient.book_count.ToString();
            ViewBag.bookCount = bookCountString;
            return View();
        }

    }
}
