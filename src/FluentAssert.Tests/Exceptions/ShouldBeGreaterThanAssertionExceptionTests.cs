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
			public void Given_the_other_is_greater_than_the_input()
			{
				Test.Verify(
					with_a_non_empty_input_integer,
					with_a_larger_other_integer,
					when_building_the_exception_message,
					should_describe_the_problem_correctly
					);
			}

			private void should_describe_the_problem_correctly()
			{
				var message = "";
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
				_result = ShouldBeGreaterThanAssertionException.CreateMessage(_other.ToString(), _input.ToString());
			}

			private void with_a_larger_other_integer()
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
				var message = "";
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
				_result = ShouldBeGreaterThanAssertionException.CreateMessage(ExpectedMessageBuilder.ToDisplayableString(_other), ExpectedMessageBuilder.ToDisplayableString(_input));
			}

			private void with_a_non_empty_input_string()
			{
				_input = "hello";
			}

			private void with_an_alphabetically_higher_other_string()
			{
				_other = "Z" + _input;
			}
		}
	}
}