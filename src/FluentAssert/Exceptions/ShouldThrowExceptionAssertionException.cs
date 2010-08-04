using System;

namespace FluentAssert.Exceptions
{
	public class ShouldThrowExceptionAssertionException : AssertionException
	{
		public ShouldThrowExceptionAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public ShouldThrowExceptionAssertionException(Type type)
			: base(CreateMessage(type, null))
		{
		}

		public ShouldThrowExceptionAssertionException(Type expectedType, Exception actualException)
			: base(CreateMessage(expectedType, actualException))
		{
			throw new NotImplementedException();
		}

		public static string CreateMessage(Type type, Exception actualException)
		{
			string message = "  Should have thrown " + type.Name+Environment.NewLine;
			if (actualException != null)
			{
				message += "  But threw " + actualException.GetType().Name + ": " + actualException.Message + Environment.NewLine;
			}
			return message;
		}
	}
}