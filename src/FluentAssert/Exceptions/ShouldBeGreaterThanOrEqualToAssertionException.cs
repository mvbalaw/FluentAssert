namespace FluentAssert.Exceptions
{
	public class ShouldBeGreaterThanOrEqualToAssertionException : AssertionException
	{
		internal ShouldBeGreaterThanOrEqualToAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage(string other, string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("greater than or equal to " + other, actual);
			return message;
		}
	}
}