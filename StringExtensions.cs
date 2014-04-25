using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CS.Helpers
{
	public static class StringExtensions
	{
		/// <summary>
		/// Returns a secure string that is not null.
		/// </summary>
		public static string SafeString(this string str)
		{
			if(String.IsNullOrEmpty(str))
				return "";
			return str;
		}
		
		/// <summary>
		/// Shorten a string at a specified length and add three dots (ellipsis)
		/// </summary>
		public static string Ellipsis(this string str, int length)
		{
			return str.Ellipsis(length, false);
		}

		/// <summary>
		/// Shorten a string at a specified length/next blank and add three dots (ellipsis)
		/// </summary>
		public static string Ellipsis(this string str, int length, bool wordbreak)
		{
			string input = str;
			if (String.IsNullOrEmpty(input))
				return "";

			if (input.Length <= length)
				return input;
			
			if(wordbreak)
			{
				int pos = input.IndexOf(" ", length);
				if (pos >= 0)
					return input.Substring(0, pos) + "...";
			}
			else
			{
				return input.Substring(0, length) + "...";
			}
			return input;
		}
		
		/// <summary>
		/// Get the md5 hash of the string
		/// </summary>
		public static string ToMd5(this string str)
		{
			System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] hash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
			return BitConverter.ToString(hash).Replace("-", "").ToLower();
		}
	}
}
