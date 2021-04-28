using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CodeCafe.Models
{
	public class Querying<T>
	{
		//Used to sort the data on the page. 
		public Expression<Func<T, Object>> OrderBy { get; set; }
		public Expression<Func<T, bool>> Where { get; set; }

		private string[] valueArray;
		//Splits the data called by the query
		public string Value
		{
			set => valueArray = value.Replace(" ", "").Split('-');
		}

		public string[] GetValues() => valueArray ?? new string[0];

		//Scans to check for null values in values.
		public bool HasWhere => Where != null;
		public bool HasOrderBy => OrderBy != null;
	}
}
