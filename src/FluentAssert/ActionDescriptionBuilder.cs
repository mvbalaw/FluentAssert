//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal static class ActionDescriptionBuilder
	{
		public static string BuildFor(MulticastDelegate action)
		{
			var name = action.Method.Name;
			return BuildFor(name);
		}

		public static string BuildFor(MulticastDelegate action, string prefixToExclude)
		{
			var name = action.Method.Name;
			if (name.StartsWith(prefixToExclude, true, CultureInfo.CurrentCulture))
			{
				name = name.Substring(prefixToExclude.Length).TrimStart('_');
			}
			return BuildFor(name);
		}

		private static string BuildFor(string name)
		{
			var readable = name.SelectMany(Cleanup).ToArray();
			return new string(readable).TrimStart();
		}

		[DebuggerNonUserCode]
		[DebuggerStepThrough]
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