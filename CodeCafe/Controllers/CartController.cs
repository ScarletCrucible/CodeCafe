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
            cart.Load((Repository<Product>)productInfo);
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
                Value = "OrderItems.Product",
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

                TempData["message"] = "Added to cart!";

                Cart cart = GetSessionOrCookieCart(); // get cart object
                cart.Add(item); // adds item to session state
                cart.Save();
            }
            // redirects to index page of product controller
            return RedirectToAction("List", "Product");
        }

        [Route("Cart/[action]")]
        public IActionResult Edit(int id)
        {
            Cart cart = GetSessionOrCookieCart();   // get cart object
            CartItem item = cart.GetById(id);   // check cart item for product id
            if (item == null)   // error if not exist
            {
                TempData["message"] = "Unable to edit the item.";
                return RedirectToAction("List", "Product");
            }
            else
            {
                return View(item);  // returns the searched for item
            }
        }
        [HttpPost]
        public RedirectToActionResult Edit(CartItem item)
        {
            TempData["message"] = "Item in cart has been updated";

            Cart cart = GetSessionOrCookieCart();   // gets cart object
            cart.Edit(item);    // edit item
            cart.Save();

            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            TempData["message"] = "Item removed from cart";

            Cart cart = GetSessionOrCookieCart();
            CartItem item = cart.GetById(id);
            cart.Remove(item);  // removes item id from cart
            cart.Save();

            return RedirectToAction("List", "Product");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            TempData["message"] = "Cart has been cleared";

            Cart cart = GetSessionOrCookieCart();
            cart.Clear();   // cleared cart after getting cart object
            cart.Save();

            return RedirectToAction("List", "Product");
        }

        [Route("Checkout")]
        public ViewResult Checkout()
        {
            return View();
        }
    }
}