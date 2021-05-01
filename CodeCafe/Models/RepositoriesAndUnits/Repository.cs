using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CodeCafe.Models.ViewModels;

namespace CodeCafe.Models.RepositoriesAndUnits
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected CafeContext context { get; set; }
        private DbSet<T> setDatabase { get; set; }
        public Repository(CafeContext ctx)
        {
            context = ctx;
            setDatabase = context.Set<T>();
        }

        private int? count;

        public int Count => count ?? setDatabase.Count();

        // used to query data and output later
        public virtual IEnumerable<T> List(Querying<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.ToList();
        }

        // used to find/change/save data
        public virtual T Get(int id) => setDatabase.Find(id);
        public virtual T Get(string id) => setDatabase.Find(id);
        public virtual T Get(Querying<T> options)
        {
            IQueryable<T> query = BuildQuery(options);
            return query.FirstOrDefault();
        }
        public virtual void Insert(T entity) => setDatabase.Add(entity);
        public virtual void Delete(T entity) => setDatabase.Remove(entity);
        public virtual void Update(T entity) => setDatabase.Update(entity);
        public virtual void Save() => context.SaveChanges();

        private IQueryable<T> BuildQuery(Querying<T> options)
        {
            IQueryable<T> query = setDatabase;
            foreach (string values in options.GetValues())
            {
                query = query.Include(values);
            }
            if (options.HasWhere)
            {
                foreach (var condition in options.WhereConditions)
                {
                    query = query.Where(condition);
                }
                count = query.Count();
            }
            if (options.HasOrderBy)
            {
                if (options.OrderByDirection == "asc")
                {
                    query = query.OrderBy(options.OrderBy);
                }
                else
                {
                    query = query.OrderByDescending(options.OrderBy);
                }
            }
            return query;
        }
    }
}