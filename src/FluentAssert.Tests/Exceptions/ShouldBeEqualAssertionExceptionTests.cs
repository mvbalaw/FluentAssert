using System;
using System.Linq;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldBeEqualAssertionExceptionTests
	{
		[TestFixture]
		public class When_creating_the_exception_message_for_two_unequal_Types
		{
			private Type _expected;
			private Type _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
			}

			[Test]
			public void Given_expected_and_input_are_non_null_and_not_the_same_object()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_non_null_expected_Type,
					when_building_the_exception_message,
					should_describe_the_Type_differences_correctly
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_Type_is_null()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_null_expected_Type,
					when_building_the_exception_message,
					should_describe_the_Type_differences_correctly
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_Type_is_not_null()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_a_non_null_expected_Type,
					when_building_the_exception_message,
					should_describe_the_Type_differences_correctly
					);
			}

			private void should_describe_the_Type_differences_correctly()
			{
				string message = "";
				try
				{
					Assert.AreEqual(_expected, _input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}
				_result.ShouldBeEqualTo(message);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeEqualAssertionException.CreateMessage(_input, _expected);
			}

			private void with_a_non_null_expected_Type()
			{
				_expected = typeof(string);
			}

			private void with_a_non_null_input_Type()
			{
				_input = typeof(decimal);
			}

			private void with_a_null_expected_Type()
			{
				_expected = null;
			}

			private void with_a_null_input_Type()
			{
				_input = null;
			}
		}

		[TestFixture]
		public class When_creating_the_exception_message_for_two_unequal_integers
		{
			private int _expected;
			private int _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
			}

			[Test]
			public void Given_two_different_values()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_non_default_expected_integer,
					when_building_the_exception_message,
					should_describe_the_differences_correctly
					);
			}

			private void should_describe_the_differences_correctly()
			{
				string message = "";
				try
				{
					Assert.AreEqual(_expected, _input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}
				_result.ShouldBeEqualTo(message);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeEqualAssertionException.CreateMessage(_input, _expected);
			}

			private void with_a_non_default_expected_integer()
			{
				_expected = 1000;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}
		}

		[TestFixture]
		public class When_creating_the_exception_message_for_two_unequal_strings
		{
			private string _expected;
			private string _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
			}

			[Test]
			public void Given_input_and_expected_are_different_lengths_and_neither_starts_with_the_other()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_expected_string_of_different_length_and_content,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_different_lengths_and_the_expected_string_starts_with_the_input_string()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_expected_string_that_starts_with_the_input_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_different_lengths_and_the_input_string_starts_with_the_expected_string()
			{
				Test.Verify(
					with_a_non_empty_expected_string,
					with_an_input_string_that_starts_with_the_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_same_length_and_differ_at_the_beginning()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_expected_string_of_equal_length_differing_at_the_beginning,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_same_length_and_differ_at_the_end()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_expected_string_of_equal_length_differing_at_the_end,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_very_long_and_differ_at_the_end()
			{
				Test.Verify(
					with_a_very_long_input_string,
					with_a_very_long_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_is_short_and_the_expected_is_very_long()
			{
				Test.Verify(
					with_a_short_input_string,
					with_a_very_long_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_input_is_very_long_and_the_expected_is_short()
			{
				Test.Verify(
					with_a_very_long_input_string,
					with_a_short_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_the_input_is_empty_and_the_expected_string_is_not_empty()
			{
				Test.Verify(
					with_an_empty_input_string,
					with_a_non_empty_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_the_input_is_not_empty_and_the_expected_string_is_empty()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_an_empty_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_the_input_is_not_empty_and_the_expected_string_is_null()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_null_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_string_is_not_empty()
			{
				Test.Verify(
					with_a_null_input_string,
					with_a_non_empty_expected_string,
					when_building_the_exception_message,
					should_describe_the_string_differences_correctly
					);
			}

			private void should_describe_the_string_differences_correctly()
			{
				string message = "";
				try
				{
					Assert.AreEqual(_expected, _input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldBeEqualAssertionException.CreateMessage(_input, _expected);
			}

			private void with_a_non_empty_expected_string()
			{
				_expected = "World";
			}

			private void with_a_non_empty_input_string()
			{
				_input = "hello";
			}

			private void with_a_null_expected_string()
			{
				_expected = null;
			}

			private void with_a_null_input_string()
			{
				_input = null;
			}

			private void with_a_short_expected_string()
			{
				_expected = "world";
			}

			private void with_a_short_input_string()
			{
				_input = "hello";
			}

			private void with_a_very_long_expected_string()
			{
				_expected = String.Join(",", Enumerable.Range(1, 50).Select(x => x.ToString()).ToArray());
			}

			private void with_a_very_long_input_string()
			{
				_input = String.Join(",", Enumerable.Range(1, 40).Select(x => x.ToString()).ToArray());
			}

			private void with_an_empty_expected_string()
			{
				_expected = "";
			}

			private void with_an_empty_input_string()
			{
				_input = "";
			}

			private void with_an_expected_string_of_different_length_and_content()
			{
				_expected = "Old";
			}

			private void with_an_expected_string_of_equal_length_differing_at_the_beginning()
			{
				_expected = "World";
			}

			private void with_an_expected_string_of_equal_length_differing_at_the_end()
			{
				_expected = "hellO";
			}

			private void with_an_expected_string_that_starts_with_the_input_string()
			{
				_expected = _input + "!";
			}

			private void with_an_input_string_that_starts_with_the_expected_string()
			{
				_input = _expected + "!";
			}
		}
	}
}