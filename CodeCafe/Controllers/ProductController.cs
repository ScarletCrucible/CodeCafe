using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models;
using CodeCafe.Models.Repository;

namespace CodeCafe.Controllers
{
    public class ProductController : Controller
    {
        //Uses the CafeUnitOfWork class to get items from the database
        private CafeUnitOfWork productInfo { get; set; }
        public ProductController(CafeContext ctx) => productInfo = new CafeUnitOfWork(ctx);
        public ViewResult List()
        {
            var plvm = new ProductListViewModel
            {
                Products = productInfo.Products.List(new Querying<Product>
                {
                    OrderBy = p => p.ProductName
                })
            };
            return View(plvm);
        }
    }
}
