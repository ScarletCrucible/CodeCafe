﻿namespace CodeCafe.Models
{
	public class Nav
	{
		public static string Active(string value, string current) =>
			(value == current) ? "active" : "";
		public static string Active(int value, int current) =>
			(value == current) ? "active" : "";
	}
}
