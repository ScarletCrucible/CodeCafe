using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CodeCafe.Models.RepositoriesAndUnits
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(Querying<T> options);

        int Count { get; }

        T Get(Querying<T> options);
        T Get(int id);
        T Get(string id);

        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}