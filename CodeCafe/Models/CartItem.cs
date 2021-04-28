using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCafe.Models.DTO;
using Newtonsoft.Json;

namespace CodeCafe.Models
{
	public class CartItem
	{
		public ProductDTO Product { get; set; }
		public int Quantity { get; set; }

		[JsonIgnore]
		public double Subtotal => Product.Price * Quantity;
	}
}
