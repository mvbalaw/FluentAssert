namespace FluentAssert.Exceptions
{
	public class ShouldBeNullAssertionException : AssertionException
	{
		public ShouldBeNullAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage(string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("null", actual);
			return message;
		}
	}
}