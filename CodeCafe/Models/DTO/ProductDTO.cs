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
		public string Description { get; set; }
		public Dictionary<int, string> Items { get; set; }

		public void Load(Product product)
		{
			ProductId = product.ProductId;
			ProductName = product.ProductName;
			Price = product.Price;
			Items = new Dictionary<int, string>();
			foreach (OrderItem oi in product.OrderItems)
			{
				Items.Add(oi.Product.ProductId, oi.Product.ProductName);
			}
		}
	}
}
