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
		private const string CartKey = "userCart";
		private const string CountKey = "userCount";	//Display how many items are in the cart. 

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

		//Loads the cart with the session state and/or cookie data. 
		public void Load(Repository<Product> info)
		{
			items = session.GetObject<List<CartItem>>(CartKey);	//Stores session objects in items. 
			if (items == null)	//If returns as null, carItems is initialized with the collection of items in persistent cookies. 
			{
				items = new List<CartItem>();
				cartItems = getCookies.GetObject<List<CartItemDTO>>(CartKey);
			}
			if (cartItems?.Count > items?.Count)
			{
				foreach (CartItemDTO cartItem in cartItems)
				{
					var product = info.Get(new Querying<Product>
					{
					});
					if (product != null)
					{
						var dto = new ProductDTO();
						dto.Load(product);

						CartItem item = new CartItem
						{
							Product = dto,
							Quantity = cartItem.Quantity
						};
						items.Add(item);
					}
				}
				Save();
			}

		}
	}
}
