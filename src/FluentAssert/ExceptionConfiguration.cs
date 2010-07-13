using System;

namespace FluentAssert
{
	public class ExceptionConfiguration
	{
		public ExceptionConfiguration()
		{
		}

		public ExceptionConfiguration(Type expectedExceptionType)
		{
			ExpectedExceptionType = expectedExceptionType;
			ExpectException = true;
		}

		public ExceptionConfiguration(Type expectedExceptionType, string expectedExceptionMessage)
		{
			ExpectedExceptionType = expectedExceptionType;
			ExpectException = true;
			ExpectedExceptionMessage = expectedExceptionMessage;
			ExpectExceptionMessage = true;
		}

		public bool ExpectException { get; private set; }
		public bool ExpectExceptionMessage { get; private set; }
		public string ExpectedExceptionMessage { get; private set; }
		public Type ExpectedExceptionType { get; private set; }

		public void CaughtExpectedException()
		{
			ExpectException = false;
		}
	}
}