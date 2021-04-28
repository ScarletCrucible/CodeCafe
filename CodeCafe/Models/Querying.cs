using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CodeCafe.Models
{
    public class WhereConditions<T> : List<Expression<Func<T, bool>>> { }
    public class Querying<T>
    {
        // used to sort data displayed 
        public Expression<Func<T, Object>> OrderBy { get; set; }
        public WhereConditions<T> WhereConditions { get; set; }
        public Expression<Func<T, bool>> Where
        {
            set
            {
                if (WhereConditions == null)
                {
                    WhereConditions = new WhereConditions<T>();
                }
                WhereConditions.Add(value);
            }
        }

        private string[] valueArray;
        // splits up the data called by the query
        public string Value
        {
            set => valueArray = value.Replace(" ", "").Split('-');
        }

        public string[] GetValues() => valueArray ?? new string[0];

        // scans that check for null values
        public bool HasWhere => WhereConditions != null;
        public bool HasOrderBy => OrderBy != null;
    }
}