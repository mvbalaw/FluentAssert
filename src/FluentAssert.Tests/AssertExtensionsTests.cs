//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System;
using System.Collections.Generic;

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
		public class When_asserting_that_a_boolean_should_be_true
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
					when_asserting_that_the_value_is_true,
					should_throw_a_ShouldBeTrueAssertionException
					);
			}

			[Test]
			public void Given_a_true_input()
			{
				Test.Verify(
					with_a_true_input,
					when_asserting_that_the_value_is_true,
					should_not_throw_an_exception
					);
			}

			private void should_not_throw_an_exception()
			{
				Assert.IsNull(_exception);
			}

			private void should_throw_a_ShouldBeTrueAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeTrueAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_value_is_true()
			{
				try
				{
					_input.ShouldBeTrue();
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
		public class When_asserting_that_a_boolean_should_be_true_with_a_Func_to_get_the_specific_error_message
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
					when_asserting_that_the_value_is_true,
					should_throw_a_ShouldBeTrueAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_a_false_input_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_false_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_true,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_a_true_input_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_true_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_true,
					should_not_throw_an_exception
					);
			}

			[Test]
			public void Given_a_true_input_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_true_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_value_is_true,
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

			private void should_throw_a_ShouldBeTrueAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeTrueAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_value_is_true()
			{
				try
				{
					_input.ShouldBeTrue(_getErrorMessage);
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
		public class When_asserting_that_a_boolean_should_be_true_with_a_specific_error_message
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
					when_asserting_that_the_value_is_true_with_a_specific_error_message,
					should_throw_a_ShouldBeTrueAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_a_true_input()
			{
				Test.Verify(
					with_a_true_input,
					when_asserting_that_the_value_is_true_with_a_specific_error_message,
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

			private void should_throw_a_ShouldBeTrueAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeTrueAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_value_is_true_with_a_specific_error_message()
			{
				try
				{
					_input.ShouldBeTrue(ExpectedErrorMessage);
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
		public class When_asserting_that_a_nullable_integer_should_be_null
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
					should_throw_a_ShouldBeNullAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_nullable_integer_is_not_null,
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

			private void should_throw_a_ShouldBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_nullable_integer_is_not_null()
			{
				try
				{
					_result = _input.ShouldBeNull();
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
		public class When_asserting_that_a_nullable_integer_should_be_null_with_a_Func_to_get_the_specific_error_message
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
					should_throw_a_ShouldBeNullAssertionException,
					should_get_the_expected_message
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
					should_return_the_input,
					should_not_throw_an_exception
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

			private void should_throw_a_ShouldBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeNullAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_nullable_integer_is_not_null()
			{
				try
				{
					_result = _input.ShouldBeNull(_getErrorMessage);
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
		public class When_asserting_that_a_nullable_integer_should_be_null_with_a_specific_error_message
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
					should_throw_a_ShouldBeNullAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_nullable_integer_is_not_null_with_a_specific_error_message,
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

			private void should_throw_a_ShouldBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_nullable_integer_is_not_null_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeNull(ExpectedErrorMessage);
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
		public class When_asserting_that_a_string_should_be_null
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
					should_throw_a_ShouldBeNullAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_string_is_not_null,
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

			private void should_throw_a_ShouldBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_string_is_not_null()
			{
				try
				{
					_result = _input.ShouldBeNull();
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
		public class When_asserting_that_a_string_should_be_null_with_a_Func_to_get_the_specific_error_message
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
					should_throw_a_ShouldBeNullAssertionException,
					should_get_the_expected_message
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
					should_return_the_input,
					should_not_throw_an_exception
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

			private void should_throw_a_ShouldBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeNullAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_string_is_not_null()
			{
				try
				{
					_result = _input.ShouldBeNull(_getErrorMessage);
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
		public class When_asserting_that_a_string_should_be_null_with_a_specific_error_message
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
					should_throw_a_ShouldBeNullAssertionException,
					should_get_the_expected_message
					);
			}

			[Test]
			public void Given_the_input_is_null()
			{
				Test.Verify(
					with_a_null_input,
					when_asserting_that_the_string_is_not_null_with_a_specific_error_message,
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
				Assert.AreSame(_input, _result);
			}

			private void should_throw_a_ShouldBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeNullAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_string_is_not_null_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeNull(ExpectedErrorMessage);
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
		public class When_asserting_that_one_integer_should_be_greater_than_another
		{
			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanAssertionException), _exception.GetType());
                _exception.Message.ShouldBeEqualTo(String.Format(@"  Expected: greater than {0}
  But was:  {1}
", _other, _input));
            }

			private void when_asserting_that_the_input_is_greater_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThan(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_greater_than_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
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

			private void should_throw_a_ShouldBeGreaterThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThan(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_greater_than_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeGreaterThan(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_greater_than_or_equal_to_another
		{
			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanOrEqualToAssertionException), _exception.GetType());
			    _exception.Message.ShouldBeEqualTo(String.Format(@"  Expected: greater than or equal to {0}
  But was:  {1}
", _other, _input));
			}

			private void when_asserting_that_the_input_is_greater_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThanOrEqualTo(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_greater_than_or_equal_to_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
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

			private void should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanOrEqualToAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThanOrEqualTo(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_greater_than_or_equal_to_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanOrEqualToAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeGreaterThanOrEqualTo(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_less_than_another
		{
			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_less_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
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

			private void should_throw_a_ShouldBeLessThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanAssertionException), _exception.GetType());
                _exception.Message.ShouldBeEqualTo(String.Format(@"  Expected: less than {0}
  But was:  {1}
", _other, _input));
			}

			private void when_asserting_that_the_input_is_less_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThan(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = _input + 1;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 0 + _input;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_less_than_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_an_ArgumentNullException
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

			private void should_throw_a_ShouldBeLessThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThan(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_less_than_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanAssertionException
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

			private void should_throw_a_ShouldBeLessThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeLessThan(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_less_than_or_equal_to_another
		{
			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_a_ShouldBeLessThanOrEqualToAssertionException
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

			private void should_throw_a_ShouldBeLessThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanOrEqualToAssertionException), _exception.GetType());
			    _exception.Message.ShouldBeEqualTo(String.Format(@"  Expected: less than or equal to {0}
  But was:  {1}
", _other, _input));
			}

			private void when_asserting_that_the_input_is_less_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThanOrEqualTo(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_less_than_or_equal_to_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_a_ShouldBeLessThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
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

			private void should_throw_a_ShouldBeLessThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanOrEqualToAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThanOrEqualTo(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_integer_should_be_less_than_or_equal_to_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private int _input;
			private int _other;
			private int _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = 0;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_other_integer_being_the_same_object,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_matching_other_integer,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_larger_other_integer,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_integers_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_integer,
					with_a_lower_other_integer,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanOrEqualToAssertionException
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

			private void should_throw_a_ShouldBeLessThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanOrEqualToAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeLessThanOrEqualTo(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_larger_other_integer()
			{
				_other = 1000;
			}

			private void with_a_lower_other_integer()
			{
				_other = _input - 1;
			}

			private void with_a_matching_other_integer()
			{
				_other = 6;
			}

			private void with_a_non_default_input_integer()
			{
				_input = 6;
			}

			private void with_other_integer_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_greater_than_another
		{
			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThan(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_greater_than_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_null_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_the_other,
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

			private void should_throw_a_ShouldBeGreaterThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanAssertionException), _exception.GetType());
			}

			private void should_throw_a_ShouldNotBeNullAssertionException()
			{
				Assert.AreEqual(typeof(ShouldNotBeNullAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThan(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_a_null_input_string()
			{
				_input = null;
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_greater_than_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeGreaterThan(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_greater_than_or_equal_to_another
		{
			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanOrEqualToAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThanOrEqualTo(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_greater_than_or_equal_to_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
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

			private void should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanOrEqualToAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeGreaterThanOrEqualTo(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_greater_than_or_equal_to_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
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

			private void should_throw_a_ShouldBeGreaterThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeGreaterThanOrEqualToAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_greater_than_or_equal_to_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeGreaterThanOrEqualTo(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_less_than_another
		{
			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_less_than_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_less_than_the_other,
					should_throw_a_ShouldBeLessThanAssertionException
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

			private void should_throw_a_ShouldBeLessThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThan(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_less_than_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Func<string> _getErrorMessage;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(with_other_string_being_the_same_object)
					.With(a_non_null_Func_to_get_the_error_message)
					.ShouldThrowException<ShouldBeLessThanAssertionException>();
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(with_other_string_being_the_same_object)
					.With(a_null_Func_to_get_the_error_message)
					.ShouldThrowException<ArgumentNullException>();
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(with_a_matching_other_string)
					.With(a_null_Func_to_get_the_error_message)
					.ShouldThrowException<ShouldBeLessThanAssertionException>();
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(with_a_matching_other_string)
					.With(a_null_Func_to_get_the_error_message)
					.ShouldThrowException<ArgumentNullException>();
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(a_larger_other_string)
					.With(a_non_null_Func_to_get_the_error_message)
					.Should(should_return_the_input);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(a_larger_other_string)
					.With(a_null_Func_to_get_the_error_message)
					.ShouldThrowException<ArgumentNullException>();
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(a_lower_other_string)
					.With(a_non_null_Func_to_get_the_error_message)
					.ShouldThrowException<ShouldBeLessThanAssertionException>();
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(a_non_default_input_string)
					.With(a_lower_other_string)
					.With(a_null_Func_to_get_the_error_message)
					.ShouldThrowException<ArgumentNullException>();
			}

			[Test]
			public void Given_the_input_is_null_and_the_error_message_Func_is_not_null()
			{
				Test.Static()
					.When(asserting_that_the_input_is_less_than_the_other)
					.With(with_a_null_input_string)
					.With(a_lower_other_string)
					.With(a_non_null_Func_to_get_the_error_message)
					.ShouldThrowException<ShouldNotBeNullAssertionException>();
			}

			private void a_larger_other_string()
			{
				_other = "ZZZ";
			}

			private void a_lower_other_string()
			{
				_other = "AAA";
			}

			private void a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void asserting_that_the_input_is_less_than_the_other()
			{
				_result = _input.ShouldBeLessThan(_other, _getErrorMessage);
			}

			private void should_return_the_input()
			{
				Assert.AreEqual(_input, _result);
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_null_input_string()
			{
				_input = null;
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_less_than_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanAssertionException
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

			private void should_throw_a_ShouldBeLessThanAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeLessThan(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_less_than_or_equal_to_another
		{
			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_a_ShouldBeLessThanOrEqualToAssertionException
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

			private void should_throw_a_ShouldBeLessThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanOrEqualToAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThanOrEqualTo(_other);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_less_than_or_equal_to_another_with_a_Func_to_get_the_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";
			private Exception _exception;
			private Func<string> _getErrorMessage;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_not_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_non_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_a_ShouldBeLessThanOrEqualToAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower_and_the_error_message_Func_is_null()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					with_a_null_Func_to_get_the_error_message,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other,
					should_throw_an_ArgumentNullException
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

			private void should_throw_a_ShouldBeLessThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanOrEqualToAssertionException), _exception.GetType());
			}

			private void should_throw_an_ArgumentNullException()
			{
				Assert.AreEqual(typeof(ArgumentNullException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_or_equal_to_the_other()
			{
				try
				{
					_result = _input.ShouldBeLessThanOrEqualTo(_other, _getErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_a_non_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = () => ExpectedErrorMessage;
			}

			private void with_a_null_Func_to_get_the_error_message()
			{
				_getErrorMessage = null;
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_one_string_should_be_less_than_or_equal_to_another_with_a_specific_error_message
		{
			private const string ExpectedErrorMessage = "Hello world";

			private Exception _exception;
			private string _input;
			private string _other;
			private string _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_other_and_are_the_same_object()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_other_string_being_the_same_object,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_are_not_the_same_object_but_are_equal()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_a_matching_other_string,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_greater()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_after_the_input,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_other_strings_are_not_the_same_object_and_other_is_lower()
			{
				Test.Verify(
					with_a_non_default_input_string,
					with_an_other_string_that_alphabetically_comes_before_the_input,
					when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message,
					should_throw_a_ShouldBeLessThanOrEqualToAssertionException
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

			private void should_throw_a_ShouldBeLessThanOrEqualToAssertionException()
			{
				Assert.AreEqual(typeof(ShouldBeLessThanOrEqualToAssertionException), _exception.GetType());
			}

			private void when_asserting_that_the_input_is_less_than_or_equal_to_the_other_with_a_specific_error_message()
			{
				try
				{
					_result = _input.ShouldBeLessThanOrEqualTo(_other, ExpectedErrorMessage);
				}
				catch (Exception exception)
				{
					_exception = exception;
				}
			}

			private void with_a_matching_other_string()
			{
				_other = "" + _input;
			}

			private void with_a_non_default_input_string()
			{
				_input = "CCC";
			}

			private void with_an_other_string_that_alphabetically_comes_after_the_input()
			{
				_other = "ZZZ";
			}

			private void with_an_other_string_that_alphabetically_comes_before_the_input()
			{
				_other = "AAA";
			}

			private void with_other_string_being_the_same_object()
			{
				_other = _input;
			}
		}

		[TestFixture]
		public class When_asserting_that_two_IEnumerables_should_be_equal
		{
			private Exception _exception;
			private IEnumerable<int> _expected;
			private IEnumerable<int> _input;
			private IEnumerable<int> _result;

			[SetUp]
			public void BeforeEachTest()
			{
				_result = null;
				_exception = null;
			}

			[Test]
			public void Given_the_input_and_expected_are_both_null()
			{
				Test.Verify(
					with_a_null_input,
					with_a_null_expected,
					when_asserting_that_IEnumerables_are_equal,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_are_the_same_object()
			{
				Test.Verify(
					with_a_null_input,
					with_expected_being_the_same_object,
					when_asserting_that_IEnumerables_are_equal,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_and_contain_different_objects()
			{
				Test.Verify(
					with_a_non_null_non_empty_input,
					with_a_non_matching_expected,
					when_asserting_that_IEnumerables_are_equal,
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_and_expected_nullable_integers_are_not_null_not_the_same_object_and_contain_the_same_objects()
			{
				Test.Verify(
					with_a_non_null_non_empty_input,
					with_a_matching_expected,
					when_asserting_that_IEnumerables_are_equal,
					should_not_throw_an_exception,
					should_return_the_input
					);
			}

			[Test]
			public void Given_the_input_is_not_null_and_the_expected_is_null()
			{
				Test.Verify(
					with_a_non_null_non_empty_input,
					with_a_null_expected,
					when_asserting_that_IEnumerables_are_equal,
					should_throw_a_ShouldBeEqualAssertionException
					);
			}

			[Test]
			public void Given_the_input_is_null_and_the_expected_is_not_null()
			{
				Test.Verify(
					with_a_null_input,
					with_a_non_null_non_empty_expected,
					when_asserting_that_IEnumerables_are_equal,
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

			private void when_asserting_that_IEnumerables_are_equal()
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

			private void with_a_matching_expected()
			{
				_expected = new List<int>(_input);
			}

			private void with_a_non_matching_expected()
			{
				_expected = new[] { 1000 };
			}

			private void with_a_non_null_non_empty_expected()
			{
				_expected = new[] { 7 };
			}

			private void with_a_non_null_non_empty_input()
			{
				_input = new List<int>
				{
					6
				};
			}

			private void with_a_null_expected()
			{
				_expected = null;
			}

			private void with_a_null_input()
			{
				_input = null;
			}

			private void with_expected_being_the_same_object()
			{
				_expected = _input;
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
			public void Given_the_input_and_expected_strings_are_not_null_and_not_equal_and_different_lengths()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_non_matching_expected_string_with_a_different_length,
					when_asserting_that_strings_are_equal,
					should_throw_a_ShouldBeEqualAssertionException,
					should_not_compare_the_strings_as_IEnumerables
					);
			}

			[Test]
			public void Given_the_input_and_expected_strings_are_not_null_and_not_equal_and_the_same_length()
			{
				Test.Verify(
					with_a_non_null_input_string,
					with_a_non_matching_expected_string_with_the_same_length,
					when_asserting_that_strings_are_equal,
					should_throw_a_ShouldBeEqualAssertionException,
					should_not_compare_the_strings_as_IEnumerables
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

			private void should_not_compare_the_strings_as_IEnumerables()
			{
				_exception.Message.ShouldNotStartWith("  Expected " + _expected.Length + " items");
				_exception.Message.ShouldNotStartWith("  Expected list");
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

			private void with_a_non_matching_expected_string_with_a_different_length()
			{
				_expected = _input + "!";
			}

			private void with_a_non_matching_expected_string_with_the_same_length()
			{
				_expected = "hell0";
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