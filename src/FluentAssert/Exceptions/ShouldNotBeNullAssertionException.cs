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
			string message = ExpectedMessageBuilder.BuildFor("not null", "null");
			return message;
		}
	}
}