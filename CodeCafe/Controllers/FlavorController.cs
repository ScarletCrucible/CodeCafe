using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models.RepositoriesAndUnits;
using CodeCafe.Models;

namespace CodeCafe.Controllers
{
	public class FlavorController : Controller
	{
		private Repository<Flavor> flavorInfo { get; set; }
		public FlavorController(CafeContext ctx) => flavorInfo = new Repository<Flavor>(ctx);
		public IActionResult Index()
		{
			return View();
		}
	}
}
