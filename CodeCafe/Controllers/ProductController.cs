using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models;
using CodeCafe.Models.RepositoriesAndUnits;

namespace CodeCafe.Controllers
{
    public class ProductController : Controller
    {
        private Repository<Product> product { get; set; }
        public ProductController(CafeContext ctx) => product = new Repository<Product>(ctx);
        public ViewResult Index()
        {
            var products = product.List(new Querying<Product> { OrderBy = a => a.ProductName });

            return View(products);
        }
    }
}