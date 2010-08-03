namespace FluentAssert.Exceptions
{
	public class ShouldBeTrueAssertionException : AssertionException
	{
		public ShouldBeTrueAssertionException()
			: base(CreateMessage())
		{
		}

		public ShouldBeTrueAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage()
		{
			string message = ExpectedMessageBuilder.BuildFor("True", "False");
			return message;
		}
	}
}