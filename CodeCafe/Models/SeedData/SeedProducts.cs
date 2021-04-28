using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeCafe.Models.SeedData
{
	public class SeedProducts : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> entity)
		{
			//real seed data added later
			entity.HasData(
				new Order { ProductId = 1, ProductName = "Cappucino", Price = 2.99, Description = "Cappucino" },
				new Order { ProductId = 2, ProductName = "Mocha Frappe", Price = 2.99, Description = "Mocha Frappe" },
				new Order { ProductId = 3, ProductName = "Caramel Frappe", Price = 2.99, Description = "Caramel Frappe" },
				new Order { ProductId = 4, ProductName = "Black Coffee", Price = 1, Description = "Black Coffee" }
			);
		}
	}
}
