using System;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldBeGreaterThanOrEqualToAssertionExceptionTests
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
			public void Given_the_other_is_greater_than_the_input()
			{
				Test.Verify(
					with_a_non_empty_input_integer,
					with_a_greater_other_integer,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.That(_input, Is.GreaterThanOrEqualTo(_other));
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeGreaterThanOrEqualToAssertionException.CreateMessage(_other.ToString(), _input.ToString());
			}

			private void with_a_greater_other_integer()
			{
				_other = 1 + _input;
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
			public void Given_the_other_is_alphabetically_higher()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_alphabetically_higher_other_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.That(_input, Is.GreaterThanOrEqualTo(_other));
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeGreaterThanOrEqualToAssertionException.CreateMessage(ExpectedMessageBuilder.ToDisplayableString(_other), ExpectedMessageBuilder.ToDisplayableString(_input));
			}

			private void with_a_non_empty_input_string()
			{
				_input = "hello";
			}

			private void with_an_alphabetically_higher_other_string()
			{
				_other = "Z" + _input;
			}

			private void with_an_empty_input_string()
			{
				_input = "";
			}
		}
	}
}