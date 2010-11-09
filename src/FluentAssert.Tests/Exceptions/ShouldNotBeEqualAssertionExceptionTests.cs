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

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ShouldNotBeEqualAssertionExceptionTests
	{
		[TestFixture]
		public class When_creating_the_exception_message_for_two_equal_Types
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
			public void Given_input_and_expected_are_the_same()
			{
				Test.Verify(
					with_a_non_empty_input_Type,
					with_a_matching_expected_Type,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.AreNotEqual(_expected, _input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldNotBeEqualAssertionException.CreateMessage(_input, _expected);
			}

			private void with_a_matching_expected_Type()
			{
				_expected = _input;
			}

			private void with_a_non_empty_input_Type()
			{
				_input = typeof(string);
			}
		}

		[TestFixture]
		public class When_creating_the_exception_message_for_two_equal_integers
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
			public void Given_input_and_expected_are_the_same()
			{
				Test.Verify(
					with_a_non_empty_input_integer,
					with_a_matching_expected_integer,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.AreNotEqual(_expected, _input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldNotBeEqualAssertionException.CreateMessage(_input, _expected);
			}

			private void with_a_matching_expected_integer()
			{
				_expected = _input;
			}

			private void with_a_non_empty_input_integer()
			{
				_input = 6;
			}
		}

		[TestFixture]
		public class When_creating_the_exception_message_for_two_equal_strings
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
			public void Given_input_and_expected_are_both_empty()
			{
				Test.Verify(
					with_an_empty_input_string,
					with_a_matching_expected_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_both_null()
			{
				Test.Verify(
					with_an_empty_input_string,
					with_a_matching_expected_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			[Test]
			public void Given_input_and_expected_are_not_null_and_the_same()
			{
				Test.Verify(
					with_a_non_empty_input_string,
					with_a_matching_expected_string,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				string message = "";
				try
				{
					Assert.AreNotEqual(_expected, _input);
				}
				catch (Exception exception)
				{
					message = exception.Message;
				}

				Assert.AreEqual(message, _result);
			}

			private void when_building_the_exception_message()
			{
				_result = ShouldNotBeEqualAssertionException.CreateMessage(_input, _expected);
			}

			private void with_a_matching_expected_string()
			{
				_expected = _input;
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