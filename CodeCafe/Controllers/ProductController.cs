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
        private IRepository<Product> productInfo { get; set; }
        public ProductController(IRepository<Product> rep) => productInfo = rep;
        public ViewResult Index()
        {
            var plvm = new ProductListViewModel
            {
                Products = productInfo.List(new Querying<Product>
                {
                    OrderBy = p => p.ProductName
                })
            };
            return View(plvm);
        }
    }
}