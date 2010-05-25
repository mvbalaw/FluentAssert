using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentAssert
{
	internal static class ActionDescriptionBuilder
	{
		public static string BuildFor(MulticastDelegate action)
		{
			string name = action.Method.Name;
			var readable = name.SelectMany(x => Cleanup(x)).ToArray();
			return new string(readable).TrimStart();
		}

		private static IEnumerable<char> Cleanup(char c)
		{
			if (c == '_')
			{
				yield return ' ';
			}
			else if (Char.IsUpper(c))
			{
				yield return ' ';
				yield return c;
			}
			else
			{
				yield return c;
			}
		}
	}
}