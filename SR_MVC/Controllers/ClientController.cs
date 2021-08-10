using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SR_BLL;
using SR_BLL.Data;
using SR_BLL.Repos;
using SR_BLL.Services;
using SR_MVC.Infrastructure.Session;
using SR_MVC.Models.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR_MVC.Controllers
{
    public class ClientController : Controller
    {

        private readonly IClientRepo _clientRepo;
        private readonly ISessionManager _sessionManager;
        public ClientController(IClientRepo clientRepo, ISessionManager sessionManager)
        {
            _clientRepo = clientRepo;
            _sessionManager = sessionManager;
        }

        // GET: ClientController
        public IActionResult ShowClient(int id)
        {
            Client client = _clientRepo.Get(id);
           
            return View(new DisplayClient()
            {
                Id = client.Id,
                lname = client.lname,
                fname = client.fname,
                bdate = client.bdate,
                book_count = client.book_count,
                email = client.email,
                is_vip = client.is_vip
            });
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            RegisterForm form = new RegisterForm();
            return View(form);
        }

        [HttpPost]

        public IActionResult Create(RegisterForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            Client newClient = new Client(form.FirstName, form.LastName, form.Bdate, form.Email, form.Pass, form.CCard, form.IdCard, default, default, true);

            _clientRepo.Register(newClient);
            return RedirectToAction("Index");
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
