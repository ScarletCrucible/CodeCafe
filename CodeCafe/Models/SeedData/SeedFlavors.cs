using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeCafe.Models.SeedData
{
	public class SeedFlavors : IEntityTypeConfiguration<Flavor>
	{
		public void Configure(EntityTypeBuilder<Flavor> entity)
		{
			entity.HasData(
				new Flavor { FlavorId = 1, FlavorName = "Bitter" },
				new Flavor { FlavorId = 2, FlavorName = "Fruity" },
				new Flavor { FlavorId = 3, FlavorName = "Salty" },
				new Flavor { FlavorId = 4, FlavorName = "Sweet" }
			);
		}
	}
}
