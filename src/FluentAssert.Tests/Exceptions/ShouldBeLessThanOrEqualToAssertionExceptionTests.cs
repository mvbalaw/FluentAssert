using System;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldBeLessThanOrEqualToAssertionExceptionTests
	{
		[TestFixture]
		public class When_creating_the_exception_message_for_two_integers
		{
			private int _input;
			private int _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
			}

			[Test]
			public void Given_the_other_is_less_than_the_input()
			{
				Test.Verify(
					with_a_non_empty_input_integer,
					with_a_lower_other_integer,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.That(_input, Is.LessThanOrEqualTo(_other));
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeLessThanOrEqualToAssertionException.CreateMessage(_other.ToString(), _input.ToString());
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_non_empty_input_integer()
			{
				_input = 6;
			}
		}

		[TestFixture]
		public class When_creating_the_exception_message_for_two_strings
		{
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
			}

			[Test]
			public void Given_the_other_is_alphabetically_lower()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_other_string_that_sorts_alphabetically_before_the_input,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.That(_input, Is.LessThanOrEqualTo(_other));
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeLessThanOrEqualToAssertionException.CreateMessage(ExpectedMessageBuilder.ToDisplayableString(_other), ExpectedMessageBuilder.ToDisplayableString(_input));
			}

			private void with_a_non_empty_input_string()
			{
				_input = "hello";
			}

			private void with_an_other_string_that_sorts_alphabetically_before_the_input()
			{
				_other = "A" + _input;
			}
		}
	}
}