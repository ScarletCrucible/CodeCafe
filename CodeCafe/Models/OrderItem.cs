using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCafe.Models
{
	public class OrderItem
	{
		public int ProductId { get; set; }
		public int FlavorId { get; set; }

		public Product Product { get; set; }
		public Flavor Flavor { get; set; }
	}
}
