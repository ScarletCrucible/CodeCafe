using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCafe.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult CheckOut()
        {
            TempData["Message"] = "Submitted";

            return RedirectToAction("Index", "Home");
        }
    }
}
