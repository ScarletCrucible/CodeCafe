using System;
using System.Collections.Generic;
using System.Linq;
using CodeCafe.Models;
using CodeCafe.Models.RepositoriesAndUnits;

namespace CodeCafe.Models.Repository
{
	public interface ICafeUnitOfWork
	{
		Repository<Product> Products { get; }
		Repository<OrderItem> OrderItems { get; }

		void Save();
	}
}
