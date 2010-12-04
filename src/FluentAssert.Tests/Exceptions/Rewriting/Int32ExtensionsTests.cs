//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using FluentAssert.Exceptions.Rewriting;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions.Rewriting
{
	public class Int32ExtensionsTests
	{
		[TestFixture]
		public class When_asked_to_convert_an_int_to_a_7bit_variable_length_byte_array
		{
			private byte[] _expected;
			private int _input;
			private byte[] _result;

			[Test]
			public void Given_a_value_that_can_be_encoded_in_1_7bit_byte()
			{
				_expected = new byte[]
				{
					0x0c
				};
				Test.Verify(
					a_value_that_can_be_encoded_in_1_7bit_byte,
					when_asked_to_convert_to_a_7bit_variable_length_byte_array,
					should_return_the_expected_byte_values
					);
			}

			[Test]
			public void Given_a_value_that_must_be_encoded_in_2_7bit_bytes()
			{
				_expected = new byte[]
				{
					0xe8, 0x0c
				};
				Test.Verify(
					a_value_that_must_be_encoded_in_2_7bit_bytes,
					when_asked_to_convert_to_a_7bit_variable_length_byte_array,
					should_return_the_expected_byte_values
					);
			}

			[Test]
			public void Given_a_value_that_must_be_encoded_in_3_7bit_bytes()
			{
				_expected = new byte[]
				{
					0xd1, 0xe8, 0x0c
				};
				Test.Verify(
					a_value_that_must_be_encoded_in_3_7bit_bytes,
					when_asked_to_convert_to_a_7bit_variable_length_byte_array,
					should_return_the_expected_byte_values
					);
			}

			[Test]
			public void Given_a_value_that_must_be_encoded_in_4_7bit_bytes()
			{
				_expected = new byte[]
				{
					0xfc, 0xd1, 0xe8, 0x0c
				};
				Test.Verify(
					a_value_that_must_be_encoded_in_4_7bit_bytes,
					when_asked_to_convert_to_a_7bit_variable_length_byte_array,
					should_return_the_expected_byte_values
					);
			}

			[Test]
			public void Given_zero()
			{
				_expected = new byte[] { 0x00 };
				Test.Verify(
					with_value_0,
					when_asked_to_convert_to_a_7bit_variable_length_byte_array,
					should_return_the_expected_byte_values
					);
			}

			private void a_value_that_can_be_encoded_in_1_7bit_byte()
			{
				_input = 0x0c;
			}

			private void a_value_that_must_be_encoded_in_2_7bit_bytes()
			{
				_input = 0x668;
			}

			private void a_value_that_must_be_encoded_in_3_7bit_bytes()
			{
				_input = 0x33451;
			}

			private void a_value_that_must_be_encoded_in_4_7bit_bytes()
			{
				_input = 0x19A28FC;
			}

			private void should_return_the_expected_byte_values()
			{
				_result.ShouldContainAllInOrder(_expected);
			}

			private void when_asked_to_convert_to_a_7bit_variable_length_byte_array()
			{
				_result = _input.To7bitVariableLengthByteArray();
			}

			private void with_value_0()
			{
				_input = 0;
			}
		}
	}
}