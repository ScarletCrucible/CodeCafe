using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models.RepositoriesAndUnits;
using CodeCafe.Models;


namespace CodeCafe.Controllers
{
    public class HomeController : Controller
    {
        private Repository<Product> productInfo { get; set; }
        public HomeController(CafeContext ctx) => productInfo = new Repository<Product>(ctx);

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
