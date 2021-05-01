using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models.DTO;
using CodeCafe.Models.RepositoriesAndUnits;
using CodeCafe.Models.SessionState;
using Microsoft.AspNetCore.Http;

namespace CodeCafe.Models
{
	public class Cart
	{
		//Private properties/objects
		private const string CartKey = "userCart";
		private const string CountKey = "userCount";    //Display how many items are in the cart. 

		//List of cart items
		private List<CartItem> items { get; set; }
		private List<CartItemDTO> cartItems { get; set; }

		//Session state objects for storing items in cart over multiple visits. 
		private ISession session { get; set; }
		private IRequestCookieCollection getCookies { get; set; }
		private IResponseCookies giveCookies { get; set; }

		//Constructor that sets the private session/cookie properties. 
		public Cart(HttpContext ctx)
		{
			session = ctx.Session;
			getCookies = ctx.Request.Cookies;
			giveCookies = ctx.Response.Cookies;
		}

		//Cart Modifiers
		public void Add(CartItem item)
		{
			var inCart = GetById(item.Product.ProductId);
			if (inCart == null) //Checks to see if the item is in the cart already
			{
				items.Add(item);
			}
			else
			{
				inCart.Quantity += 1;   //Adds 1 quantity if it exists. 
			}
		}

		public void Remove(CartItem item) => items.Remove(item);
		public void Clear() => items.Clear();

		public void Save()
		{
			//Without this, cart would say 0 for count. 
			if (items.Count == 0)
			{
				session.Remove(CartKey);
				session.Remove(CountKey);

				giveCookies.Delete(CartKey);
				giveCookies.Delete(CountKey);
			}
			else
			{
				session.SetInt32(CountKey, items.Count);    //Sets count for items in cart
				giveCookies.SetInt32(CountKey, items.Count);    //Sets count in cookies

				session.SetObject<List<CartItem>>(CartKey, items);  //Stores collection of the objects in List
				giveCookies.SetObject<List<CartItemDTO>>(CartKey, items.ToDTO()); //Also stores in the ToDTO method to keep the users' cart stored over multiple visits
			}
		}

		//Loads the cart with the session state and/or cookie data. 
		public void Load(Repository<Product> info)
		{
			items = session.GetObject<List<CartItem>>(CartKey); //Stores session objects in items. 
			if (items == null)  //If returns as null, carItems is initialized with the collection of items in persistent cookies. 
			{
				items = new List<CartItem>();
				cartItems = getCookies.GetObject<List<CartItemDTO>>(CartKey);
			}
			if (cartItems?.Count > items?.Count)
			{
				//Gets products from database and checks if it is null. If null, it doesn't get processed. 
				foreach (CartItemDTO cartItem in cartItems)
				{
					var product = info.Get(new Querying<Product>
					{
						Value = "OrderItems.Flavor",
						Where = p => p.ProductId == cartItem.ProductId
					});
					//If not null, a new Product object is created and passed to the ProductDTO
					if (product != null)
					{
						var productdto = new ProductDTO();
						productdto.Load(product);

						//Creates new CartItem by storing the product and the quantity and adding it to the items
						CartItem item = new CartItem
						{
							Product = productdto,
							Quantity = cartItem.Quantity
						};
						items.Add(item);
					}
				}
				Save();
			}
		}

		//public properties/objects
		public double Subtotal => items.Sum(s => s.Subtotal);   //Adds the subtotal per item in the cart

		//Returns number of items in the cart using session state, and if it has to, from cookies
		public int? Count => session.GetInt32(CountKey) ?? getCookies.GetInt32(CountKey);

		public IEnumerable<CartItem> List => items; //Puts the CartItem objects into the List collection

		//Gets CartItem whose id matches the argument id 
		public CartItem GetById(int id) =>
			items.FirstOrDefault(ci => ci.Product.ProductId == id);
	}
}
