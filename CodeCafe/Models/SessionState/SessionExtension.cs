using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CodeCafe.Models.SessionState
{
	//Ch09
	public static class SessionExtension
	{
		public static void SetObject<T>(this ISession session, string key, T value) =>
			session.SetString(key, JsonConvert.SerializeObject(value)); //Stores a T type object in the session state object

		public static T GetObject<T>(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);    //Retrieves T type object from the session state object
		}
	}
}
