using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeCafe.Models.RepositoriesAndUnits
{
	public class Repository<T> : IRepository<T> where T : class
	{
		protected CafeContext contxt { get; set; }
		private DbSet<T> setDatabase { get; set; }

		public Repository(CafeContext ctx)
		{
			contxt = ctx;
			setDatabase = contxt.Set<T>();
		}

		//Used to Query (and eventually output) the data
		public virtual IEnumerable<T> List(Querying<T> options)
		{
			IQueryable<T> query = setDatabase;

			foreach (string values in options.GetValues())
			{
				query = query.Include(values);
			}

			if (options.HasWhere)
			{
				query = query.Where(options.Where);
			}
			if (options.HasOrderBy)
			{
				query = query.OrderBy(options.OrderBy);
			}
			return query.ToList();
		}

		//Used to find, modify, and save the data when needed.
		public virtual T Get(int id) => setDatabase.Find(id);
		public virtual void Insert(T entity) => setDatabase.Add(entity);
		public virtual void Delete(T entity) => setDatabase.Remove(entity);
		public virtual void Update(T entity) => setDatabase.Update(entity);
		public virtual void Save() => contxt.SaveChanges();
	}
}
