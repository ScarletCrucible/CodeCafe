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
				new OrderItem { ProductId = 1 },
				new OrderItem { ProductId = 2 },
				new OrderItem { ProductId = 3 },
				new OrderItem { ProductId = 4 }
			);
		}
	}
}
