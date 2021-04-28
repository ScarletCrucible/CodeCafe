using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CodeCafe.Models
{
    public class Querying<T>
    {
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }

        private string[] valueArray;
        public string Value
        {
            set => valueArray = value.Replace(" ", "").Split('-');
        }

        public string[] GetValues() => valueArray ?? new string[0];

        public bool HasWhere => Where != null;
        public bool HasOrderBy => OrderBy != null;
    }
}