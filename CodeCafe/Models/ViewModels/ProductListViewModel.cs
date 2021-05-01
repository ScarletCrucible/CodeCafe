using System.Collections.Generic;

namespace CodeCafe.Models
{
	public class ProductListViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Flavor> Flavors { get; set; }
	}
}
