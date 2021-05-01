using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeCafe.Models.SeedData
{
	public class SeedProducts : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> entity)
		{
			entity.HasData(
				new Product { ProductId = 1, ProductName = "Reg. Cappucino", Price = 2.99, Description = "Steamed milk and espresso", Image = "/images/Cappuccino.jpg" },
				new Product { ProductId = 2, ProductName = "Small Mocha Frappe", Price = 2.99, Description = "Rich cocoa espresso", Image = "/images/MochaFrappe.jpg" },
				new Product { ProductId = 3, ProductName = "Medium Mocha Frappe", Price = 2.99, Description = "Rich cocoa espresso", Image = "/images/MochaFrappe.jpg" },
				new Product { ProductId = 4, ProductName = "Large Mocha Frappe", Price = 2.99, Description = "Rich cocoa espresso", Image = "/images/MochaFrappe.jpg" },
				new Product { ProductId = 5, ProductName = "Small Caramel Frappe", Price = 2.99, Description = "Salty caramel espresso", Image = "/images/CaramelFrappe.jpg" },
				new Product { ProductId = 6, ProductName = "Medium Caramel Frappe", Price = 2.99, Description = "Salty caramel espresso", Image = "/images/CaramelFrappe.jpg" },
				new Product { ProductId = 7, ProductName = "Large Caramel Frappe", Price = 2.99, Description = "Salty caramel espresso", Image = "/images/CaramelFrappe.jpg" },
				new Product { ProductId = 8, ProductName = "Small Black Coffee", Price = 1, Description = "Light roast black coffee", Image = "/images/BlackCoffee.jpg" },
				new Product { ProductId = 9, ProductName = "Medium Black Coffee", Price = 1, Description = "Light roast black coffee", Image = "/images/BlackCoffee.jpg" },
				new Product { ProductId = 10, ProductName = "Large Black Coffee", Price = 1, Description = "Light roast black coffee", Image = "/images/BlackCoffee.jpg" }
			);
		}
	}
}
