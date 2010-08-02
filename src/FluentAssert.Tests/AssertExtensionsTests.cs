using System;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests
{
	public class AssertExtensionsTests
	{
		[TestFixture]
		public class When_asserting_that_a_boolean_should_be_false
		{
			private Exception _exception;
			private bool _input;

			[SetUp]
			public void BeforeEachTest()
			{
				_exception = null;
			}

			[Test]
			public void Given_a_false_input()
			{
				Test.Verify(
					with_a_false_input,
					when_asserting_that_the_value_is_false,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_a_true_input()
			{
				Test.Verify(
					with_a_true_input,
					when_asserting_that_the_value_is_false,
					should_throw_a_ShouldBeFalseAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_throw_a_ShouldBeFalseAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeFalseAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_value_is_false()
			{
				try
				{
					_input.ShouldBeFalse();
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_false_input()
			{
				_input = false;
			}

			private void with_a_true_input()
			{
				_input = true;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_boolean_should_be_false_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello World";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private bool _input;

			[SetUp]
			public void BeforeEachTest()
			{
				_exception = null;
			}

			[Test]
			public void Given_a_false_input_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_false_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_false,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_a_false_input_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_false_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_false,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_a_true_input_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_true_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_false,
					should_throw_a_ShouldBeFalseAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_a_true_input_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_true_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_false,
					should_throw_an_ArgumentNullException
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_throw_a_ShouldBeFalseAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeFalseAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_value_is_false()
			{
				try
				{
					_input.ShouldBeFalse(_getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_false_input()
			{
				_input = false;
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_a_true_input()
			{
				_input = true;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_boolean_should_be_false_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello World";
			private Exception _exception;
			private bool _input;

			[SetUp]
			public void BeforeEachTest()
			{
				_exception = null;
			}

			[Test]
			public void Given_a_false_input()
			{
				Test.Verify(
					with_a_false_input,
					when_asserting_that_the_value_is_false_with_a_specific_error_message,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_a_true_input()
			{
				Test.Verify(
					with_a_true_input,
					when_asserting_that_the_value_is_false_with_a_specific_error_message,
					should_throw_a_ShouldBeFalseAssertionException,
					should_get_the_expected_message
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_throw_a_ShouldBeFalseAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeFalseAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_value_is_false_with_a_specific_error_message()
			{
				try
				{
					_input.ShouldBeFalse(ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_false_input()
			{
				_input = false;
			}

			private void with_a_true_input()
			{
				_input = true;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_nullable_integer_should_not_be_null
		{
			private Exception _exception;
			private int? _input;
			private int? _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_is_not_null()
			{
				Test.Verify(
					with_a_non_null_input,
					when_asserting_that_the_nullable_integer_is_not_null,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_nullable_integer_is_not_null,
					should_throw_a_ShouldNotBeNullAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_nullable_integer_is_not_null()
			{
				try
				{
					_result = _input.ShouldNotBeNull();
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_non_null_input()
			{
				_input = 6;
			}

			private void with_a_null_input()
			{
				_input = null;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_nullable_integer_should_not_be_null_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private Func<string> _getErrorMessage;
			private int? _input;
			private int? _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_null_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_nullable_integer_is_not_null,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_null_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_nullable_integer_is_not_null,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_null_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_nullable_integer_is_not_null,
					should_throw_a_ShouldNotBeNullAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_null_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_nullable_integer_is_not_null,
					should_throw_an_ArgumentNullException
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_nullable_integer_is_not_null()
			{
				try
				{
					_result = _input.ShouldNotBeNull(_getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_non_null_input()
			{
				_input = 6;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_a_null_input()
			{
				_input = null;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_nullable_integer_should_not_be_null_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private int? _input;
			private int? _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_is_not_null()
			{
				Test.Verify(
					with_a_non_null_input,
					when_asserting_that_the_nullable_integer_is_not_null_with_a_specific_error_message,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_nullable_integer_is_not_null_with_a_specific_error_message,
					should_throw_a_ShouldNotBeNullAssertionException,
					should_get_the_expected_message
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_nullable_integer_is_not_null_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldNotBeNull(ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_non_null_input()
			{
				_input = 6;
			}

			private void with_a_null_input()
			{
				_input = null;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_string_should_not_be_null
		{
			private Exception _exception;
			private string _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_is_not_null()
			{
				Test.Verify(
					with_a_non_null_input,
					when_asserting_that_the_string_is_not_null,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_string_is_not_null,
					should_throw_a_ShouldNotBeNullAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_string_is_not_null()
			{
				try
				{
					_result = _input.ShouldNotBeNull();
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_non_null_input()
			{
				_input = "Hello";
			}

			private void with_a_null_input()
			{
				_input = null;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_string_should_not_be_null_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private string _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_null_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_string_is_not_null,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_null_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_string_is_not_null,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_null_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_string_is_not_null,
					should_throw_a_ShouldNotBeNullAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_null_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_string_is_not_null,
					should_throw_an_ArgumentNullException
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_string_is_not_null()
			{
				try
				{
					_result = _input.ShouldNotBeNull(_getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_non_null_input()
			{
				_input = "Hello";
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_a_null_input()
			{
				_input = null;
			}
		}

		[TestFixture]
		public class When_asserting_that_a_string_should_not_be_null_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private string _input;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_is_not_null()
			{
				Test.Verify(
					with_a_non_null_input,
					when_asserting_that_the_string_is_not_null_with_a_specific_error_message,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_string_is_not_null_with_a_specific_error_message,
					should_throw_a_ShouldNotBeNullAssertionException,
					should_get_the_expected_message
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_string_is_not_null_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldNotBeNull(ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_non_null_input()
			{
				_input = "Hello";
			}

			private void with_a_null_input()
			{
				_input = null;
			}
		}

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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_matching_expected_Type,
					when_asserting_that_Types_are_equal,
					should_not_throw_an_exception,
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_Type_is_not_null()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_a_non_null_expected_Type,
					when_asserting_that_Types_are_equal,
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeEqualAssertionException), _exception.GetType());
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
		public class When_asserting_that_two_Types_should_not_be_equal
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
					when_asserting_that_Types_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_not_null_and_not_equal()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_non_matching_expected_Type,
					when_asserting_that_Types_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_matching_expected_Type,
					when_asserting_that_Types_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_Types_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_expected_Type_being_the_same_object,
					when_asserting_that_Types_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_Type_is_null()
			{
				Test.Verify(
					with_a_non_null_input_Type,
					with_a_null_expected_Type,
					when_asserting_that_Types_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_Type_is_not_null()
			{
				Test.Verify(
					with_a_null_input_Type,
					with_a_non_null_expected_Type,
					when_asserting_that_Types_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldNotBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeEqualAssertionException), _exception.GetType());
			}

			private void when_asserting_that_Types_are_not_equal()
			{
				try
				{
					_result = _input.ShouldNotBeEqualTo(_expected);
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
					should_not_throw_an_exception,
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeEqualAssertionException), _exception.GetType());
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
		public class When_asserting_that_two_integers_should_not_be_equal
		{
			private Exception _exception;
			private int _expected;
			private int _input;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_are_the_different()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_non_matching_expected_integer,
					when_asserting_that_integers_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_the_same()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_expected_integer,
					when_asserting_that_integers_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeEqualAssertionException), _exception.GetType());
			}

			private void when_asserting_that_integers_are_not_equal()
			{
				try
				{
					_result = _input.ShouldNotBeEqualTo(_expected);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_expected_integer()
			{
				_expected = _input;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_a_non_matching_expected_integer()
			{
				_expected = _input + 1;
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_matching_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_not_throw_an_exception,
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_nullable_integer_is_not_null()
			{
				Test.Verify(
					with_a_null_input_nullable_integer,
					with_a_non_null_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_equal,
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeEqualAssertionException), _exception.GetType());
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
		public class When_asserting_that_two_nullable_integers_should_not_be_equal
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
					when_asserting_that_nullable_integers_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_and_not_equal()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_non_matching_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_matching_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input_nullable_integer,
					with_expected_nullable_integer_being_the_same_object,
					when_asserting_that_nullable_integers_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_nullable_integer_is_null()
			{
				Test.Verify(
					with_a_non_null_input_nullable_integer,
					with_a_null_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_nullable_integer_is_not_null()
			{
				Test.Verify(
					with_a_null_input_nullable_integer,
					with_a_non_null_expected_nullable_integer,
					when_asserting_that_nullable_integers_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeEqualAssertionException), _exception.GetType());
			}

			private void when_asserting_that_nullable_integers_are_not_equal()
			{
				try
				{
					_result = _input.ShouldNotBeEqualTo(_expected);
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_matching_expected_string,
					when_asserting_that_strings_are_equal,
					should_not_throw_an_exception,
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_string_is_not_null()
			{
				Test.Verify(
					with_a_null_input_string,
					with_a_non_null_expected_string,
					when_asserting_that_strings_are_equal,
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeEqualAssertionException), _exception.GetType());
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
		public class When_asserting_that_two_strings_should_not_be_equal
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
					when_asserting_that_strings_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_not_null_and_not_equal()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_non_matching_expected_string,
					when_asserting_that_strings_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_not_null_not_the_same_object_and_equal()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_matching_expected_string,
					when_asserting_that_strings_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input_string,
					with_expected_string_being_the_same_object,
					when_asserting_that_strings_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_string_is_null()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_null_expected_string,
					when_asserting_that_strings_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_string_is_not_null()
			{
				Test.Verify(
					with_a_null_input_string,
					with_a_non_null_expected_string,
					when_asserting_that_strings_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldNotBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeEqualAssertionException), _exception.GetType());
			}

			private void when_asserting_that_strings_are_not_equal()
			{
				try
				{
					_result = _input.ShouldNotBeEqualTo(_expected);
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException,
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

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeEqualAssertionException), _exception.GetType());
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
					should_not_throw_an_exception,
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
					should_throw_a_ShouldBeEqualAssertionException,
					should_get_the_expected_message
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeEqualAssertionException), _exception.GetType());
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

		[TestFixture]
		public class When_asserting_that_two_things_should_not_be_equal_with_a_Func_to_get_the_specific_error_message
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
					when_asserting_that_items_are_not_equal,
					should_throw_a_ShouldNotBeEqualAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_and_expected_and_are_the_same_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_matching_expected_item,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_items_are_not_equal,
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
					when_asserting_that_items_are_not_equal,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_different_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_non_matching_expected_item,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_items_are_not_equal,
					should_throw_an_ArgumentNullException
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeEqualAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_items_are_not_equal()
			{
				try
				{
					_result = _input.ShouldNotBeEqualTo(_expected, _getErrorMessage);
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
		public class When_asserting_that_two_things_should_not_be_equal_with_a_specific_error_message
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
					when_asserting_that_items_are_not_equal_with_a_specific_error_message,
					should_throw_a_ShouldNotBeEqualAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_different()
			{
				Test.Verify(
					with_a_non_default_input_item,
					with_a_non_matching_expected_item,
					when_asserting_that_items_are_not_equal_with_a_specific_error_message,
					should_return_the_input,
					should_not_throw_an_exception
					);
			}

			private void should_get_the_expected_message()
			{
				_exception.Message.ShouldBeEqualTo(ExpectedErrorMessage);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void should_throw_a_ShouldNotBeEqualAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeEqualAssertionException), _exception.GetType());
			}

			private void when_asserting_that_items_are_not_equal_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldNotBeEqualTo(_expected, ExpectedErrorMessage);
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