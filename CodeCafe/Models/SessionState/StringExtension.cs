using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeCafe.Models.SessionState
{
	public static class StringExtension
	{
		public static string Slug(this string str)
		{
			var strbuild = new StringBuilder();

			//Takes strings, replaces spaces with dashes and makes all letters lowercase.
			foreach (char character in str)
			{
				if (!char.IsPunctuation(character) || character == '-')
				{
					strbuild.Append(character);
				}
			}
			return strbuild.ToString().Replace(' ', '-').ToLower();
		}

		//Compares strings and ignores casing
		public static bool Comparison(this string str, string toCompare) => str?.ToLower() == toCompare?.ToLower();

		//If needed, this method converts a string to an int. 
		public static int ToInteger(this string str)
		{
			int.TryParse(str, out int id);
			return id;
		}

		//Capitalizes the first letter of a string and makes the rest of the letters lowercase.
		public static string Capitalization(this string str) =>
			str?.Substring(0, 1)?.ToUpper() + str?.Substring(1).ToLower();
	}
}
