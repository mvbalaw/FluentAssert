using System;

namespace FluentAssert
{
	public class AssertionException : Exception
	{
		protected AssertionException(string message)
			: base(message)
		{
		}
	}
}