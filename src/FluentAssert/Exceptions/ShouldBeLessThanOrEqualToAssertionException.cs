namespace FluentAssert.Exceptions
{
	public class ShouldBeLessThanOrEqualToAssertionException : AssertionException
	{
		internal ShouldBeLessThanOrEqualToAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage(string other, string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("less than or equal to " + other, actual);
			return message;
		}
	}
}