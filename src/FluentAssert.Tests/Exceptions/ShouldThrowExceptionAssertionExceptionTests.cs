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
	public class ShouldThrowExceptionAssertionExceptionTests
	{
		[TestFixture]
		public class When_creating_the_exception_message_for_an_expected_exception_type
		{
			private Exception _actualException;
			private Type _expectedExceptionType;
			private string _result;

			[Test]
			public void Given_an_expected_exception_type_and_an_actual_exception()
			{
				Test.Verify(
					with_an_expected_exception_type,
					with_a_non_null_actual_exception,
					when_building_the_default_exception_message,
					should_describe_the_expected_type_and_the_actual_exception
					);
			}

			[Test]
			public void Given_only_the_expected_exception_type()
			{
				Test.Verify(
					with_an_expected_exception_type,
					with_a_null_actual_exception,
					when_building_the_default_exception_message,
					should_only_describe_the_expected_type
					);
			}

			private string GetExpectedExceptionDescription()
			{
				return "  Should have thrown " + _expectedExceptionType.Name + Environment.NewLine;
			}

			private void should_describe_the_expected_type_and_the_actual_exception()
			{
				var expected = GetExpectedExceptionDescription();
				var actual = "  But threw " + _actualException.GetType().Name + ": " + _actualException.Message + Environment.NewLine;
				_result.ShouldBeEqualTo(expected + actual);
			}

			private void should_only_describe_the_expected_type()
			{
				var expected = GetExpectedExceptionDescription();
				_result.ShouldBeEqualTo(expected);
			}

			private void when_building_the_default_exception_message()
			{
				_result = ShouldThrowExceptionAssertionException.CreateMessage(_expectedExceptionType, _actualException);
			}

			private void with_a_non_null_actual_exception()
			{
// ReSharper disable once NotResolvedInText
				_actualException = new ArgumentOutOfRangeException("foo");
			}

			private void with_a_null_actual_exception()
			{
				_actualException = null;
			}

			private void with_an_expected_exception_type()
			{
				_expectedExceptionType = typeof(ArgumentNullException);
			}
		}
	}
}