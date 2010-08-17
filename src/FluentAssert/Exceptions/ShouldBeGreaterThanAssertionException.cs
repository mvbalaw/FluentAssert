namespace FluentAssert.Exceptions
{
	public class ShouldBeGreaterThanAssertionException : AssertionException
	{
		internal ShouldBeGreaterThanAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage(string other, string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("greater than " + other, actual);
			return message;
		}
	}
}