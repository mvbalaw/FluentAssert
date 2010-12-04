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
	public class BinarySerializationAssemblyInfoSegmentTests
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
				               	0x0C, 0x02
				               };

				_stream = new MemoryStream(bytes)
				{
					Position = 0
				};
				_segment = new BinarySerializationAssemblyInfoSegment();
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
			public void Given_a_MemoryStream_having_byte_at_Position_equal_to_0x0C()
			{
				Test.Verify(
					with_type_id_at_position_equal_to_0x0C,
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
				_stream.Position = _initialPosition = 1;
			}

			private void with_type_id_at_position_equal_to_0x0C()
			{
				_stream.Position = _initialPosition = 0;
			}
		}

		[TestFixture]
		public class When_asked_to_Skip
		{
			private IBinarySerializationSegment _segment;
			private MemoryStream _stream;

			[SetUp]
			public void BeforeEachTest()
			{
				byte[] bytes = {
				               	0x0C, 0x02, 0x00, 0x00, 0x00, 0x43, 0x46, 0x6C, 0x75, 0x65, 0x6E, 0x74,
				               	0x41, 0x73, 0x73, 0x65, 0x72, 0x74, 0x2C, 0x20, 0x56, 0x65, 0x72, 0x73,
				               	0x69, 0x6F, 0x6E, 0x3D, 0x31, 0x2E, 0x30, 0x2E, 0x30, 0x2E, 0x30, 0x2C,
				               	0x20, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 0x3D, 0x6E, 0x65, 0x75,
				               	0x74, 0x72, 0x61, 0x6C, 0x2C, 0x20, 0x50, 0x75, 0x62, 0x6C, 0x69, 0x63,
				               	0x4B, 0x65, 0x79, 0x54, 0x6F, 0x6B, 0x65, 0x6E, 0x3D, 0x6E, 0x75, 0x6C,
				               	0x6C, 0x05
				               };

				_stream = new MemoryStream(bytes);
				_segment = new BinarySerializationAssemblyInfoSegment();
			}

			[Test]
			public void Given_a_stream_positioned_at_a_match()
			{
				Test.Verify(
					with_a_stream_positioned_at_a_match,
					when_asked_to_Skip,
					should_change_the_Position_to_the_first_byte_after_the_section
					);
			}

			private void should_change_the_Position_to_the_first_byte_after_the_section()
			{
				_stream.Position.ShouldBeEqualTo(_stream.Length - 1);
			}

			private void when_asked_to_Skip()
			{
				_segment.Skip(_stream);
			}

			private void with_a_stream_positioned_at_a_match()
			{
				_stream.Position = 0;
			}
		}
	}
}