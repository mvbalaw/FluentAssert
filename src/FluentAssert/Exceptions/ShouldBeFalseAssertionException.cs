namespace FluentAssert.Exceptions
{
	public class ShouldBeFalseAssertionException : AssertionException
	{
		public ShouldBeFalseAssertionException()
			: base(CreateMessage())
		{
		}

		public ShouldBeFalseAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage()
		{
			string message = ExpectedMessageBuilder.BuildFor("False", "True");
			return message;
		}
	}
}