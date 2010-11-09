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
using System.Linq;

using FluentAssert.Exceptions;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions
{
	public class ExpectedMessageBuilderTests
	{
		[TestFixture]
		public class When_asked_to_get_the_displayable_string_for_a_string_with_a_difference_index
		{
			private int _differenceIndex;
			private string _input;
			private string _result;

			[Test]
			public void Given_a_short_non_empty_input()
			{
				Test.Verify(
					with_a_short_non_empty_input,
					when_asked_to_get_the_displayable_string_for_a_string_with_a_difference_index,
					should_return_a_quoted_result
					);
			}

			[Test]
			public void Given_an_empty_input()
			{
				Test.Verify(
					with_an_empty_input,
					when_asked_to_get_the_displayable_string_for_a_string_with_a_difference_index,
					should_return_the_empty_string_description
					);
			}

			[Test]
			public void Given_an_input_that_should_be_shortened_and_a_difference_index_larger_than_the_maximum()
			{
				Test.Verify(
					with_an_input_that_should_be_shortened,
					with_a_difference_index_larger_than_the_maximum,
					when_asked_to_get_the_displayable_string_for_a_string_with_a_difference_index,
					should_return_a_quoted_result,
					should_return_the_input_shortened_to_max,
					should_prefix_the_result_with_an_ellipsis,
					should_not_append_an_ellipsis_to_the_result
					);
			}

			[Test]
			public void Given_an_input_that_should_be_shortened_and_a_difference_index_smaller_than_the_maximum()
			{
				Test.Verify(
					with_an_input_that_should_be_shortened,
					with_a_difference_index_smaller_than_the_maximum,
					when_asked_to_get_the_displayable_string_for_a_string_with_a_difference_index,
					should_return_a_quoted_result,
					should_return_the_input_shortened_to_max,
					should_not_prefix_the_result_with_an_ellipsis,
					should_append_an_ellipsis_to_the_result
					);
			}

			private void should_append_an_ellipsis_to_the_result()
			{
				_result.ShouldEndWith(ExpectedMessageBuilder.Ellipsis + "\"");
			}

			private void should_not_append_an_ellipsis_to_the_result()
			{
				_result.ShouldNotEndWith(ExpectedMessageBuilder.Ellipsis + "\"");
			}

			private void should_not_prefix_the_result_with_an_ellipsis()
			{
				_result.ShouldNotStartWith("\"" + ExpectedMessageBuilder.Ellipsis);
			}

			private void should_prefix_the_result_with_an_ellipsis()
			{
				_result.ShouldStartWith("\"" + ExpectedMessageBuilder.Ellipsis);
			}

			private void should_return_a_quoted_result()
			{
				_result.ShouldStartWith("\"");
				_result.ShouldEndWith("\"");
			}

			private void should_return_the_empty_string_description()
			{
				_result.ShouldBeEqualTo("<string.Empty>");
			}

			private void should_return_the_input_shortened_to_max()
			{
				const int lengthOfTwoQuotes = 2;
				_result.Length.ShouldBeEqualTo(ExpectedMessageBuilder.MaxStringLength + ExpectedMessageBuilder.Ellipsis.Length + lengthOfTwoQuotes);
			}

			private void when_asked_to_get_the_displayable_string_for_a_string_with_a_difference_index()
			{
				_result = ExpectedMessageBuilder.ToDisplayableString(_input, _differenceIndex);
			}

			private void with_a_difference_index_larger_than_the_maximum()
			{
				_differenceIndex = ExpectedMessageBuilder.MaxStringLength + 1;
			}

			private void with_a_difference_index_smaller_than_the_maximum()
			{
				_differenceIndex = 10;
			}

			private void with_a_short_non_empty_input()
			{
				_input = "hello";
			}

			private void with_an_empty_input()
			{
				_input = "";
			}

			private void with_an_input_that_should_be_shortened()
			{
				_input = String.Join(",", Enumerable.Range(1, 50).Select(x => x.ToString()).ToArray());
				Assert.IsTrue(_input.Length > ExpectedMessageBuilder.MaxStringLength, "make this string longer than the max");
			}
		}
	}
}