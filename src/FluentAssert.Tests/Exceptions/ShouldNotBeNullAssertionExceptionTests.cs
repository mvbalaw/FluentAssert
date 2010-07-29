using System;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldNotBeNullAssertionExceptionTests
	{
		[TestFixture]
		public class When_creating_the_exception_message_for_a_null_input
		{
			private string _result;

			[Test]
			public void Should_describe_the_problem_correctly()
			{
				Test.Verify(
					when_building_the_default_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.IsNotNull(null);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}
				_result.ShouldBeEqualTo(message);
			}

			private void when_building_the_default_exception_message()
			{
				_result = ShouldNotBeNullAssertionException.CreateMessage();
			}
		}
	}
}