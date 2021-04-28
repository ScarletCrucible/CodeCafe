using System.Collections.Generic;

namespace CodeCafe.Models
{
	public class ProductListViewModel
	{
		public IEnumerable<Product> Products { get; set; }
		/*public RouteDictionary CurrentRoute { get; set; }*/
		public Dictionary<string, string> Prices =>
			new Dictionary<string, string>
			{
				{"regular", "Regular" },
			};
	}
}
