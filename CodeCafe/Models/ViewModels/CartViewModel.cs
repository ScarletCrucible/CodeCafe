using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCafe.Models.ViewModels
{
	public class CartViewModel
	{
		public IEnumerable<CartItem> List { get; set; }
		public double Subtotal { get; set; }
	}
}
