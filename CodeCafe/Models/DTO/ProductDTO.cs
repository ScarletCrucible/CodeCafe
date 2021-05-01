using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCafe.Models.DTO
{
	public class ProductDTO
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public double Price { get; set; }
		public Dictionary<int, string> Flavors { get; set; }

		public void Load(Product product)
		{
			ProductId = product.ProductId;
			ProductName = product.ProductName;
			Price = product.Price;
			Flavors = new Dictionary<int, string>();
			foreach (OrderItem oi in product.OrderItems)
			{
				Flavors.Add(oi.Product.ProductId, oi.Flavor.FlavorName);
			}
		}
	}
}
