using EFCoreMVCMacoratti.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreMVCMacoratti.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (var context = new AppDbContext())
            {
                /*var user = new Users() { Nome = "AnaClara", Email = "anaclara@eu.com", Id = 6 };
                context.Users.Add(user);
                context.SaveChanges();*/
                var query = context.Users.Where(x => x.Nome == "Maria").FirstOrDefault();
                var name = query.Nome;
                ViewData["name"] = name;
            }
            return View();
        }

        public IActionResult Formulario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Formulario (string nome, string email)
        {
            using (var context = new AppDbContext())
            {
                var query = context.Users.Where(x => x.Nome == nome && x.Email == email).FirstOrDefault();
                /*ViewData["result"] = query.ToString();*/
                if (query != null)
                {
                    ViewData["result"] = query.ToString();
                } else
                {
                    ViewData["result"] = "FALSE";
                }
            }
            
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
