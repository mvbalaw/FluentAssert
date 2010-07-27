using System;

namespace FluentAssert
{
	public class NotEqualException : FluentAssert.AssertionException
	{
		public NotEqualException(object input, object expected) 
			: base(CreateMessage(input, expected))
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
				var stringInput = input as string;
				var expectedInput = expected as string;
				differenceIndex = GetDifferenceIndex(stringInput, expectedInput);
				int inputLength = stringInput.Length;
				int expectedLength = expectedInput.Length;
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
				suffix += "  " + "^".PadLeft(12 + differenceIndex, '-') + Environment.NewLine;
			}
			return prefix + message + suffix;
		}

		private static int GetDifferenceIndex(string input, string expected)
		{
			if (input.Length != expected.Length)
			{
				return 0;
			}
			for(int i = 0; i < input.Length; i++)
			{
				if (input[i] != expected[i])
				{
					return i;
				}
			}
			return input.Length;
		}

		private static string ToDisplayableString(object input)
		{
			if (input == null)
			{
				return "null";
			}
			if (input.GetType() == typeof(string))
			{
				var stringInput = input as string;
				if (stringInput.Length == 0)
				{
					input = "<string.Empty>";
				}
				else
				{
					input = "\"" + stringInput + "\"";
				}
			}
			return input.ToString();
		}

	}
}