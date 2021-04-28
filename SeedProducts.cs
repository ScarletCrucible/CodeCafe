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
            //real seed data added later
            entity.HasData(
                new Product { ProductId = 1, ProductName = "Cappucino", Price = 2.99, Description = "Cappucino" },
                new Product { ProductId = 2, ProductName = "Mocha Frappe", Price = 2.99, Description = "Mocha Frappe" },
                new Product { ProductId = 3, ProductName = "Caramel Frappe", Price = 2.99, Description = "Caramel Frappe" },
                new Product { ProductId = 4, ProductName = "Black Coffee", Price = 1, Description = "Black Coffee" }
            );
        }
    }
}