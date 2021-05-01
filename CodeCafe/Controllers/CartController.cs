using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models;
using CodeCafe.Models.RepositoriesAndUnits;
using CodeCafe.Models.DTO;
using CodeCafe.Models.ViewModels;

namespace CodeCafe.Controllers
{
    public class CartController : Controller
    {
        private Repository<Product> productInfo { get; set; }
        public CartController(CafeContext ctx) => productInfo = new Repository<Product>(ctx);   //tightly coupled dependency injection of a repository object

        private Cart GetSessionOrCookieCart()
        {
            var cart = new Cart(HttpContext);
            cart.Load(productInfo);
            return (cart);
        }

        [Route("Cart")]
        public ViewResult Index()
        {
            var cart = GetSessionOrCookieCart();

            var cvm = new CartViewModel
            {
                List = cart.List,
                Subtotal = cart.Subtotal
            };
            return View(cvm);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            // gets the book from the database
            var product = productInfo.Get(new Querying<Product>
            {
                Value = "OrderItems.Flavor",
                Where = p => p.ProductId == id
            });

            if (product == null)    // error if book not found
            {
                TempData["message"] = "Item not able to be added to cart.";
            }
            else
            {
                var productdto = new ProductDTO();  // transfer object of a product database
                productdto.Load(product);

                // initialized product with a transfer object, default quantity = 1
                CartItem item = new CartItem
                {
                    Product = productdto,
                    Quantity = 1
                };

                Cart cart = GetSessionOrCookieCart(); // get cart object
                cart.Add(item); // adds item to session state
                cart.Save();

                TempData["message"] = "Added to cart!";
            }
            // redirects to index page of product controller
            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Cart cart = GetSessionOrCookieCart();
            CartItem item = cart.GetById(id);
            cart.Remove(item);  // removes item id from cart
            cart.Save();

            TempData["message"] = "Item removed from cart";

            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Cart cart = GetSessionOrCookieCart();
            cart.Clear();   // cleared cart after getting cart object
            cart.Save();

            TempData["message"] = "Cart has been cleared";

            return RedirectToAction("List", "Product");
        }

        [Route("Checkout")]
        public ViewResult Checkout()
        {
            Cart cart = GetSessionOrCookieCart();
            cart.Clear();
            cart.Save();

            return View();
        }

        public ViewResult ThankYou()
        {
            return View();
        }
    }
}