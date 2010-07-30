using System;

namespace FluentAssert.Exceptions
{
	public class AssertionException : Exception
	{
		protected AssertionException(string errorMessage)
			: base(errorMessage)
		{
		}
	}
}