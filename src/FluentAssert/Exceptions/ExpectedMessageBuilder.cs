using System;

namespace FluentAssert.Exceptions
{
	public class ExpectedMessageBuilder
	{
		public static string BuildFor(string expected, string actual)
		{
			string message = "  Expected: " + expected + Environment.NewLine
			                 + "  But was:  " + actual + Environment.NewLine;
			return message;
		}
	}
}