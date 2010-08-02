using System;

namespace FluentAssert.Exceptions
{
	public class ExpectedMessageBuilder
	{
		public const string Ellipsis = "...";
		public const int MaxStringLength = 61;
		internal static readonly int StringLeftStart = (int)Math.Ceiling(MaxStringLength / 2.0);


		public static string BuildFor(string expected, string actual)
		{
			string message = "  Expected: " + expected + Environment.NewLine
			                 + "  But was:  " + actual + Environment.NewLine;
			return message;
		}

		public static string ToDisplayableString(object input)
		{
			if (input == null)
			{
				return "null";
			}
			var type = input.GetType();
			if (type == typeof(string))
			{
				return ToDisplayableString(input as string, 0);
			}
			if (typeof(Type).IsAssignableFrom(type))
			{
				return "<" + input + ">";
			}
			return input.ToString();
		}

		public static string ToDisplayableString(string input, int differenceIndex)
		{
			string result;
			if (input.Length == 0)
			{
				result = "<string.Empty>";
			}
			else
			{
				input = ShortenString(input, differenceIndex);
				result = QuoteString(input);
			}
			return result;
		}

		private static string QuoteString(string input)
		{
			return "\"" + input + "\"";
		}

		private static string ShortenString(string input, int differenceIndex)
		{
			if (differenceIndex > MaxStringLength)
			{
				int start = differenceIndex - StringLeftStart;
				string substring = input.Substring(start, Math.Min(input.Length - start, MaxStringLength));
				input = Ellipsis + substring;
				return input;
			}
			if (input.Length > MaxStringLength)
			{
				return input.Substring(0, MaxStringLength) + Ellipsis;
			}
			return input;
		}
	}
}