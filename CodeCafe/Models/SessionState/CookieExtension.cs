using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CodeCafe.Models.SessionState
{
	public static class CookieExtension
	{
		//returns the key value
		public static string GetString(this IRequestCookieCollection cookies, string key) => cookies[key];

		//Converts the string key to an integer and returns true or false based off success of conversion. If false, it returns null. 
		public static int? GetInt32(this IRequestCookieCollection cookies, string key) => int.TryParse(cookies[key], out int i) ? i : (int?) null;

		//Takes in the string key and if it's null it returns as default. Otherwise converts the string value to an object of type T.
		public static T GetObject<T>(this IRequestCookieCollection cookies, string key)
		{
			var value = cookies[key];
			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
		}

		//Deletes old key and creates a cookie with the expiration day (which is set to 15 days)
		public static void SetString(this IResponseCookies cookies, string key, string value, int days = 15)
		{
			cookies.Delete(key);
			if (days == 0)
			{
				cookies.Append(key, value);
			}
			else
			{
				CookieOptions options = new CookieOptions
				{
					Expires = DateTime.Now.AddDays(days)
				};
				cookies.Append(key, value, options);
			}
		}

		//Converts the parsed int back into a string and passes it to the SetString() method.
		public static void SetInt32(this IResponseCookies cookies, string key, int value, int days = 15) => cookies.SetString(key, value.ToString(), days);

		//Converts the parameters to a JSON string
		public static void SetObject<T>(this IResponseCookies cookies, string key, T value, int days = 15) =>
			cookies.SetString(key, JsonConvert.SerializeObject(value), days);
	}
}
