using System;

namespace FluentAssert.Exceptions
{
	public class AssertionException : Exception
	{
		internal AssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		internal AssertionException(string errorMessage, Exception innerException)
			: base(errorMessage, innerException)
		{
		}
	}
}