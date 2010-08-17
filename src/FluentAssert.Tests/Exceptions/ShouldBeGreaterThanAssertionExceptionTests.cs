using System;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldBeGreaterThanAssertionExceptionTests
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
			public void Given_input_and_other_are_the_same()
			{
				Test.Verify(
					with_a_non_empty_input_integer,
					with_a_matching_other_integer,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.That(_input, Is.GreaterThan(_other));
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeGreaterThanAssertionException.CreateMessage(_input.ToString(), _other.ToString());
			}

			private void with_a_matching_other_integer()
			{
				_other = _input;
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
			public void Given_input_and_other_are_both_empty()
			{
				Test.Verify(
					with_an_empty_input_string,
					with_a_matching_other_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			[Test]
			public void Given_input_and_other_are_both_null()
			{
				Test.Verify(
					with_an_empty_input_string,
					with_a_matching_other_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			[Test]
			public void Given_input_and_other_are_not_null_and_the_same()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_matching_other_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.That(_input, Is.GreaterThan(_other));
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeGreaterThanAssertionException.CreateMessage(ExpectedMessageBuilder.ToDisplayableString(_input), ExpectedMessageBuilder.ToDisplayableString(_other));
			}

			private void with_a_matching_other_string()
			{
				_other = _input;
			}

			private void with_a_non_empty_input_string()
			{
				_input = "hello";
			}

			private void with_an_empty_input_string()
			{
				_input = "";
			}
		}
	}
}