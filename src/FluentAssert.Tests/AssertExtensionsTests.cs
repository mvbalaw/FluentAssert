using System;

using NUnit.Framework;

namespace FluentAssert.Tests
{
	public class AssertExtensionsTests
	{
		[TestFixture]
		public class When_asserting_that_two_Types_should_be_equal
		{
			private Exception _exception;
			private Type _expected;
			private Type _input;
			private Type _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_both_null()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_a_null_expected_Type,
					when_asserting_that_Types_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_not_null_and_not_equal()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_non_matching_expected_Type,
					when_asserting_that_Types_are_equal,
					should_throw_a_NotEqualException
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_matching_expected_Type,
					when_asserting_that_Types_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_expected_Type_being_the_same_object,
					when_asserting_that_Types_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_Type_is_null()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_null_expected_Type,
					when_asserting_that_Types_are_equal,
					should_throw_a_NotEqualException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_Type_is_not_null()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_a_non_null_expected_Type,
					when_asserting_that_Types_are_equal,
					should_throw_a_NotEqualException
					);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_NotEqualException()
			{
				Assert.AreEqual(typeof(NotEqualException), _exception.GetType());
			}

			private void when_asserting_that_Types_are_equal()
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

			private void with_a_matching_expected_Type()
			{
				_expected = typeof(string);
			}

			private void with_a_non_matching_expected_Type()
			{
				_expected = typeof(Int32);
			}

			private void with_a_non_null_expected_Type()
			{
				_expected = typeof(decimal);
			}

			private void with_a_non_null_input_Type()
			{
				_input = typeof(string);
			}

			private void with_a_null_expected_Type()
			{
				_expected = null;
			}

			private void with_a_null_input_Type()
			{
				_input = null;
			}

			private void with_expected_Type_being_the_same_object()
			{
				_expected = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_two_integers_should_be_equal
		{
			private Exception _exception;
			private int _expected;
			private int _input;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_expected_integer_being_the_same_object,
					when_asserting_that_integers_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_expected_integer,
					when_asserting_that_integers_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_integers_are_not_the_same_object_and_not_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_non_matching_expected_integer,
					when_asserting_that_integers_are_equal,
					should_throw_a_NotEqualException
					);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_NotEqualException()
			{
				Assert.AreEqual(typeof(NotEqualException), _exception.GetType());
			}

			private void when_asserting_that_integers_are_equal()
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

			private void with_a_matching_expected_integer()
			{
				_expected = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_a_non_matching_expected_integer()
			{
				_expected = 1000;
			}

			private void with_expected_integer_being_the_same_object()
			{
				_expected = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_two_nullable_integers_should_be_equal
		{
			private Exception _exception;
			private int? _expected;
			private int? _input;
			private int? _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_both_null()
			{
				Test.Verify(
					with_a_null_input_nullable_integer,
					with_a_null_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_and_not_equal()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_non_matching_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_throw_a_NotEqualException
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_matching_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input_nullable_integer,
					with_expected_nullable_integer_being_the_same_object,
					when_asserting_that_nullable_integers_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_nullable_integer_is_null()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_null_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_throw_a_NotEqualException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_nullable_integer_is_not_null()
			{
				Test.Verify(
					with_a_null_input_nullable_integer,
					with_a_non_null_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_throw_a_NotEqualException
					);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_NotEqualException()
			{
				Assert.AreEqual(typeof(NotEqualException), _exception.GetType());
			}

			private void when_asserting_that_nullable_integers_are_equal()
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

			private void with_a_matching_expected_nullable_integer()
			{
				_expected = 6;
			}

			private void with_a_non_matching_expected_nullable_integer()
			{
				_expected = 1000;
			}

			private void with_a_non_null_expected_nullable_integer()
			{
				_expected = 7;
			}

			private void with_a_non_null_input_nullable_integer()
			{
				_input = 6;
			}

			private void with_a_null_expected_nullable_integer()
			{
				_expected = null;
			}

			private void with_a_null_input_nullable_integer()
			{
				_input = null;
			}

			private void with_expected_nullable_integer_being_the_same_object()
			{
				_expected = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_two_strings_should_be_equal
		{
			private Exception _exception;
			private string _expected;
			private string _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_both_null()
			{
				Test.Verify(
					with_a_null_input_string,
					with_a_null_expected_string,
					when_asserting_that_strings_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_not_null_and_not_equal()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_non_matching_expected_string,
					when_asserting_that_strings_are_equal,
					should_throw_a_NotEqualException
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_matching_expected_string,
					when_asserting_that_strings_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input_string,
					with_expected_string_being_the_same_object,
					when_asserting_that_strings_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_string_is_null()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_null_expected_string,
					when_asserting_that_strings_are_equal,
					should_throw_a_NotEqualException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_string_is_not_null()
			{
				Test.Verify(
					with_a_null_input_string,
					with_a_non_null_expected_string,
					when_asserting_that_strings_are_equal,
					should_throw_a_NotEqualException
					);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_NotEqualException()
			{
				Assert.AreEqual(typeof(NotEqualException), _exception.GetType());
			}

			private void when_asserting_that_strings_are_equal()
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

			private void with_a_non_matching_expected_string()
			{
				_expected = "hellO";
			}

			private void with_a_non_null_expected_string()
			{
				_expected = "World";
			}

			private void with_a_non_null_input_string()
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

			private void with_expected_string_being_the_same_object()
			{
				_expected = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_two_things_should_be_equal_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private int _expected;
			private Func<string> _getErrorMessage;
			private int _input;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_and_are_the_same_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_matching_expected_item,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_items_are_equal,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_and_are_the_same_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_matching_expected_item,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_items_are_equal,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_different_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_non_matching_expected_item,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_items_are_equal,
					should_throw_a_NotEqualException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_different_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_non_matching_expected_item,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_items_are_equal,
					should_throw_an_ArgumentNullException
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_NotEqualException()
			{
				Assert.AreEqual(typeof(NotEqualException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_items_are_equal()
			{
				try
				{
					_result = _input.ShouldBeEqualTo(_expected, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_expected_item()
			{
				_expected = 6;
			}

			private void with_a_non_default_input_item()
			{
				_input = 6;
			}

			private void with_a_non_matching_expected_item()
			{
				_expected = 1000;
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}
		}

		[TestFixture]
		public class When_asserting_that_two_things_should_be_equal_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private int _expected;
			private int _input;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_and_are_the_same()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_matching_expected_item,
					when_asserting_that_items_are_equal_with_a_specific_error_message,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_different()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_non_matching_expected_item,
					when_asserting_that_items_are_equal_with_a_specific_error_message,
					should_throw_a_NotEqualException,
					should_get_the_expected_message
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_NotEqualException()
			{
				Assert.AreEqual(typeof(NotEqualException), _exception.GetType());
			}

			private void when_asserting_that_items_are_equal_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeEqualTo(_expected, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_expected_item()
			{
				_expected = 6;
			}

			private void with_a_non_default_input_item()
			{
				_input = 6;
			}

			private void with_a_non_matching_expected_item()
			{
				_expected = 1000;
			}
		}
	}
}