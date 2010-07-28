using System;

namespace FluentAssert
{
	public class NotEqualException : AssertionException
	{
		private const string Ellipsis = "...";
		private const int MaxStringLength = 61;
		private static readonly int StringLeftStart = (int)Math.Ceiling(MaxStringLength / 2.0);

		public NotEqualException(string message)
			: base(message)
		{
		}

		public static string CreateMessage(object input, object expected)
		{
			string displayInput = ToDisplayableString(input);
			string displayExpected = ToDisplayableString(expected);
			string prefix = "";
			bool showStringDifferences = expected != null && input != null && input.GetType() == typeof(string);
			int differenceIndex = 0;
			if (showStringDifferences)
			{
				string stringInput = input as string;
				string stringExpected = expected as string;
				differenceIndex = GetDifferenceIndex(stringInput, stringExpected);
				displayInput = ToDisplayableString(stringInput, differenceIndex);
				displayExpected = ToDisplayableString(stringExpected, differenceIndex);
				int inputLength = stringInput.Length;
				int expectedLength = stringExpected.Length;
				if (inputLength == expectedLength)
				{
					prefix = "  String lengths are both " + expectedLength + ".";
				}
				else
				{
					prefix = "  Expected string length " + expectedLength + " but was " + inputLength + ".";
				}
				prefix += " Strings differ at index " + differenceIndex + "." + Environment.NewLine;
			}

			string message = "  Expected: " + displayExpected + Environment.NewLine
			                 + "  But was:  " + displayInput + Environment.NewLine;
			string suffix = "";
			if (showStringDifferences)
			{
				if (differenceIndex > displayExpected.Length)
				{
					differenceIndex = Ellipsis.Length + StringLeftStart;
				}
				suffix += "  " + "^".PadLeft(12 + differenceIndex, '-') + Environment.NewLine;
			}
			return prefix + message + suffix;
		}

		private static int GetDifferenceIndex(string input, string expected)
		{
			if (String.IsNullOrEmpty(input) || String.IsNullOrEmpty(expected))
			{
				return 0;
			}
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] != expected[i])
				{
					return i;
				}
			}
			return input.Length;
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

		private static string ToDisplayableString(object input)
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

		private static string ToDisplayableString(string input, int differenceIndex)
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
	}
}