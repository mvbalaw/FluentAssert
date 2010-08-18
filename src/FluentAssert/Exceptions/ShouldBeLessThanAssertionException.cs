namespace FluentAssert.Exceptions
{
	public class ShouldBeLessThanAssertionException : AssertionException
	{
		internal ShouldBeLessThanAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage(string other, string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("less than " + other, actual);
			return message;
		}
	}
}