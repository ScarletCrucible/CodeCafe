using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCafe.Models
{
	public class OrderItem
	{
		public int ProductId { get; set; }
		public Order Product { get; set; }
	}
}
