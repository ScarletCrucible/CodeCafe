using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeCafe.Models.SeedData
{
	public class SeedOrderItems : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> entity)
		{
			entity.HasData(
				new OrderItem { ProductId = 1, FlavorId = 4 },
				new OrderItem { ProductId = 2, FlavorId = 4 },
				new OrderItem { ProductId = 3, FlavorId = 4 },
				new OrderItem { ProductId = 4, FlavorId = 4 },
				new OrderItem { ProductId = 5, FlavorId = 4 },
				new OrderItem { ProductId = 6, FlavorId = 4 },
				new OrderItem { ProductId = 7, FlavorId = 4 },
				new OrderItem { ProductId = 8, FlavorId = 1 },
				new OrderItem { ProductId = 9, FlavorId = 1 },
				new OrderItem { ProductId = 10, FlavorId = 1 }
			);
		}
	}
}
