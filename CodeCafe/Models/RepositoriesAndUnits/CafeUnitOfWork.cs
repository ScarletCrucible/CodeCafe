using CodeCafe.Models.RepositoriesAndUnits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCafe.Models.Repository
{
	public class CafeUnitOfWork : ICafeUnitOfWork
	{
		private CafeContext contxt { get; set; }
		public CafeUnitOfWork(CafeContext ctx) => contxt = ctx;

		//Class Repository creation
		private Repository<Product> productInfo;
		public Repository<Product> Products
		{
			get
			{
				//If a repository doesn't exist for productInfo, then it creates one.
				if (productInfo == null)
				{
					productInfo = new Repository<Product>(contxt);
				}
				return productInfo;
			}
		}

		private Repository<Flavor> flavorInfo;
		public Repository<Flavor> Flavors
		{
			get
			{
				//If a repository doesn't exist for productInfo, then it creates one.
				if (flavorInfo == null)
				{
					flavorInfo = new Repository<Flavor>(contxt);
				}
				return flavorInfo;
			}
		}

		private Repository<OrderItem> orderInfo;
		public Repository<OrderItem> OrderItems
		{
			get
			{
				//If a repository doesn't exist for orderInfo, then it creates one.
				if (orderInfo == null)
				{
					orderInfo = new Repository<OrderItem>(contxt);
				}
				return orderInfo;
			}
		}
		public void Save() => contxt.SaveChanges();
	}
}
