using System;

namespace FluentAssert.Exceptions
{
	public class ShouldBeGreaterThanAssertionException : AssertionException
	{
		internal ShouldBeGreaterThanAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		internal ShouldBeGreaterThanAssertionException(string errorMessage, Exception innerException)
			: base(errorMessage, innerException)
		{
		}

		public static string CreateMessage(string other, string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("greater than " + other, actual);
			return message;
		}
	}
}