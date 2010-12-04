//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System.IO;

using FluentAssert.Exceptions.Rewriting;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions.Rewriting
{
	public class BinarySerializationPartialExceptionClassSegmentTests
	{
		[TestFixture]
		public class When_asked_if_IsMatch
		{
			private int _initialPosition;
			private bool _result;
			private IBinarySerializationSegment _segment;
			private MemoryStream _stream;

			[SetUp]
			public void BeforeEachTest()
			{
				byte[] bytes = {
				               	0x06, 0x05, 0x04, 0x01
				               };

				_stream = new MemoryStream(bytes)
				{
					Position = 0
				};
				_segment = new BinarySerializationPartialExceptionClassSegment();
			}

			[Test]
			public void Given_a_MemoryStream_having_a_non_matching_type_id_at_Position()
			{
				Test.Verify(
					with_non_matching_type_id_at_Position,
					when_asked_if_IsMatch,
					should_return_false,
					should_not_change_Position
					);
			}

			[Test]
			public void Given_a_MemoryStream_having_byte_at_Position_equal_to_0x04()
			{
				Test.Verify(
					with_type_id_at_Position_equal_to_0x04,
					when_asked_if_IsMatch,
					should_return_true,
					should_not_change_Position
					);
			}

			[Test]
			public void Given_a_MemoryStream_having_byte_at_Position_equal_to_0x05()
			{
				Test.Verify(
					with_type_id_at_Position_equal_to_0x05,
					when_asked_if_IsMatch,
					should_return_true,
					should_not_change_Position
					);
			}

			private void should_not_change_Position()
			{
				_stream.Position.ShouldBeEqualTo(_initialPosition);
			}

			private void should_return_false()
			{
				_result.ShouldBeFalse();
			}

			private void should_return_true()
			{
				_result.ShouldBeTrue();
			}

			private void when_asked_if_IsMatch()
			{
				_result = _segment.IsMatch(_stream);
			}

			private void with_non_matching_type_id_at_Position()
			{
				_stream.Position = _initialPosition = 3;
			}

			private void with_type_id_at_Position_equal_to_0x04()
			{
				_stream.Position = _initialPosition = 2;
			}

			private void with_type_id_at_Position_equal_to_0x05()
			{
				_stream.Position = _initialPosition = 1;
			}
		}

		[TestFixture]
		public class When_asked_to_Skip
		{
			private byte[] _bytes;
			private int _expectedOffset;
			private int _initialPosition;
			private BinarySerializationPartialExceptionClassSegment _segment;
			private MemoryStream _stream;

			[SetUp]
			public void BeforeEachTest()
			{
				_segment = new BinarySerializationPartialExceptionClassSegment();
			}

			[Test]
			public void Given_a_serialized_ArgumentException()
			{
				_expectedOffset = 0x156;

				Test.Verify(
					with_a_serialized_ArgumentException,
					when_asked_to_Skip,
					should_change_the_Position_to_the_first_byte_of_the_segment_containing_the_StackTrace
					);
			}

			[Test]
			public void Given_a_serialized_AssertionException()
			{
				_expectedOffset = 0x203;

				Test.Verify(
					with_a_serialized_AssertionException,
					when_asked_to_Skip,
					should_change_the_Position_to_the_first_byte_of_the_segment_containing_the_StackTrace
					);
			}

			[Test]
			public void Given_a_serialized_NotImplementedException()
			{
				_expectedOffset = 0x154;
				Test.Verify(
					with_a_serialized_NotImplementedException,
					when_asked_to_Skip,
					should_change_the_Position_to_the_first_byte_of_the_segment_containing_the_StackTrace
					);
			}

			[Test]
			public void Given_a_serialized_ShouldBeEqualAssertionException()
			{
				_expectedOffset = 0x1c7;

				Test.Verify(
					with_a_serialized_ShouldBeEqualAssertionException,
					when_asked_to_Skip,
					should_change_the_Position_to_the_first_byte_of_the_segment_containing_the_StackTrace
					);
			}

			private void should_change_the_Position_to_the_first_byte_of_the_segment_containing_the_StackTrace()
			{
				_stream.Position.ShouldBeEqualTo(_expectedOffset);
			}

			private void when_asked_to_Skip()
			{
				_stream = new MemoryStream(_bytes)
				{
					Position = _initialPosition
				};
				_segment.Skip(_stream);
			}

			private void with_a_serialized_ArgumentException()
			{
				_bytes = EmbeddedResource.Read("ArgumentException.bin");
				_initialPosition = 0x11;
			}

			private void with_a_serialized_AssertionException()
			{
				_bytes = EmbeddedResource.Read("AssertionException.bin");
				_initialPosition = 0x6c;
			}

			private void with_a_serialized_NotImplementedException()
			{
				_bytes = EmbeddedResource.Read("NotImplementedException.bin");
				_initialPosition = 0x11;
			}

			private void with_a_serialized_ShouldBeEqualAssertionException()
			{
				_bytes = EmbeddedResource.Read("ShouldBeEqualAssertionException.bin");
				_initialPosition = 0x5a;
			}
		}
	}
}