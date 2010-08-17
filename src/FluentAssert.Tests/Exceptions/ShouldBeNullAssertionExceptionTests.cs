using System;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldBeNullAssertionExceptionTests
	{
		[TestFixture]
		public class When_creating_the_exception_message_for_a_non_null_input
		{
			private string _input;
			private string _result;

			[Test]
			public void Given_a_non_empty_string()
			{
				Test.Verify(
					with_a_non_empty_string,
					when_building_the_default_exception_message,
					should_describe_the_problem_correctly
					);
			}

			[Test]
			public void Given_an_empty_string()
			{
				Test.Verify(
					with_an_empty_string,
					when_building_the_default_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.IsNull(_input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}
				_result.ShouldBeEqualTo(message);
			}

			private void when_building_the_default_exception_message()
			{
				_result = ShouldBeNullAssertionException.CreateMessage(ExpectedMessageBuilder.ToDisplayableString(_input));
			}

			private void with_a_non_empty_string()
			{
				_input = "x";
			}

			private void with_an_empty_string()
			{
				_input = "";
			}
		}
	}
}