using System;

using NUnit.Framework;

namespace FluentAssert.Tests
{
	public class AssertExtensionsTests
	{
		[TestFixture]
		public class When_asserting_that_two_strings_are_equal
		{
			private Exception _exception;
			private string _expected;
			private string _input;
			private string _result;

			[Test]
			public void Given_strings_having_different_lengths()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_expected_string_of_different_length,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			[Test]
			public void Given_strings_having_the_same_length_that_are_not_equal_differing_at_the_beginning()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_non_matching_expected_string_of_equal_length_differing_at_the_beginning,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			[Test]
			public void Given_strings_having_the_same_length_that_are_not_equal_differing_at_the_end()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_non_matching_expected_string_of_equal_length_differing_at_the_end,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			[Test]
			public void Given_strings_that_are_equal()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_matching_expected_string,
					when_asserting_that_two_non_structs_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_expected_string_is_empty_and_the_input_is_not()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_empty_expected_string,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			[Test]
			public void Given_the_expected_string_is_null_and_the_input_is_not_empty()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_null_expected_string,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			[Test]
			public void Given_the_input_is_empty_and_the_expected_string_is_not()
			{
				Test.Verify(
					with_an_empty_input_string,
					with_a_non_empty_expected_string,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_string_is_not_empty()
			{
				Test.Verify(
					with_a_null_input_string,
					with_a_non_empty_expected_string,
					when_asserting_that_two_non_structs_are_equal,
					should_throw_an_exception_with_a_message_describing_the_differences
					);
			}

			private void should_return_the_input()
			{
				_result.ShouldBeSameInstanceAs(_input);
			}

			private void should_throw_an_exception_with_a_message_describing_the_differences()
			{
				string message = NotEqualException.CreateMessage(_input, _expected);
				_exception.Message.ShouldBeEqualTo(message);
			}

			private void when_asserting_that_two_non_structs_are_equal()
			{
				try
				{
					_result = _input.ShouldBeEqualTo(_expected);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_expected_string()
			{
				_expected = "hello";
			}

			private void with_a_non_empty_expected_string()
			{
				_expected = "World";
			}

			private void with_a_non_empty_input_string()
			{
				_input = "hello";
			}

			private void with_a_non_matching_expected_string_of_equal_length_differing_at_the_beginning()
			{
				_expected = "World";
			}

			private void with_a_non_matching_expected_string_of_equal_length_differing_at_the_end()
			{
				_expected = "hellO";
			}

			private void with_a_null_expected_string()
			{
				_expected = null;
			}

			private void with_a_null_input_string()
			{
				_input = null;
			}

			private void with_an_empty_expected_string()
			{
				_expected = "";
			}

			private void with_an_empty_input_string()
			{
				_input = "";
			}

			private void with_an_expected_string_of_different_length()
			{
				_expected = "Old";
			}
		}
	}
}