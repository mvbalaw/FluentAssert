using System;

namespace FluentAssert.Exceptions
{
	public class ShouldNotBeEqualAssertionException : AssertionException
	{
		public ShouldNotBeEqualAssertionException(string input, string expected)
			: base(CreateMessage(input, expected))
		{
		}

		public ShouldNotBeEqualAssertionException(string message)
			: base(message)
		{
		}

		public static string CreateMessage(object input, object expected)
		{
			string displayInput = ExpectedMessageBuilder.ToDisplayableString(input);
			string displayExpected = ExpectedMessageBuilder.ToDisplayableString(expected);

			string message = "  Expected: not " + displayExpected + Environment.NewLine
			                 + "  But was:  " + displayInput + Environment.NewLine;

			return message;
		}
	}
}