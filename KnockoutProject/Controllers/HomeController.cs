using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KnockoutProject.ViewModels;

namespace KnockoutProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        public IActionResult VisitorsLogbookMvc()
        {
            return View();
        }

        [HttpPost]
        public IActionResult VisitorsLogbookMvc(VisitorsLogbookViewModel model)
        {
            return View(model);
        }

        public IActionResult TabSelector()
        {
            return View();
        }
    }
}
