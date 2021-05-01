using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CodeCafe.Models
{
	public class Flavor
	{
		public int FlavorId { get; set; }
		public string FlavorName { get; set; }

		public ICollection<OrderItem> OrderItems { get; set; }
	}
}
