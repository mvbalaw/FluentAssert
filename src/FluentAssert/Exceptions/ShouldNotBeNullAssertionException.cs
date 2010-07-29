using System;

namespace FluentAssert.Exceptions
{
	public class ShouldNotBeNullAssertionException : AssertionException
	{
		public ShouldNotBeNullAssertionException()
			: base(CreateMessage())
		{
		}

		public ShouldNotBeNullAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage()
		{
			string message = "  Expected: not null" + Environment.NewLine
			                 + "  But was:  null" + Environment.NewLine;
			return message;
		}
	}
}