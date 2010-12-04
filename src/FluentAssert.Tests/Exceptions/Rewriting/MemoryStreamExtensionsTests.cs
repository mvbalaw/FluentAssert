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
    public class MemoryStreamExtensionsTests
    {
        [TestFixture]
        public class When_asked_to_Peek_a_Byte
        {
            private byte[] _bytes;
            private int _initialPosition;
            private int _result;
            private MemoryStream _stream;

            [SetUp]
            public void BeforeEachTest()
            {
                _bytes = new byte[]
                {
                    0x04, 0x03, 0x02, 0x01
                };

                _stream = new MemoryStream(_bytes);
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_a_Byte()
            {
                _initialPosition = 1;
                Test.Verify(
                    with_a_stream_positioned_at_a_Byte,
                    when_asked_to_Peek_a_Byte,
                    should_return_the_Byte_at_Position,
                    should_not_change_the_Position
                    );
            }

            private void should_not_change_the_Position()
            {
                _stream.Position.ShouldBeEqualTo(_initialPosition);
            }

            private void should_return_the_Byte_at_Position()
            {
                _result.ShouldBeEqualTo(_bytes[_initialPosition]);
            }

            private void when_asked_to_Peek_a_Byte()
            {
                _result = _stream.PeekByte();
            }

            private void with_a_stream_positioned_at_a_Byte()
            {
                _stream.Position = _initialPosition;
            }
        }

        [TestFixture]
        public class When_asked_to_read_a_7_bit_variable_length_Int32
        {
            private byte[] _bytes;
            private int _expectedPosition;
            private int _expectedValue;
            private int _initialPosition;
            private int _result;
            private MemoryStream _stream;

            [SetUp]
            public void BeforeEachTest()
            {
                _bytes = new byte[]
                {
                    0x05, 0xfc, 0xd1, 0xe8, 0x0c, 0x02
                };
                _stream = new MemoryStream(_bytes);
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_1_byte_Int32()
            {
                _initialPosition = 1;

                Test.Verify(
                    with_a_stream_positioned_at_a_1_byte_Int32,
                    when_asked_to_read_a_7_bit_variable_length_Int32,
                    should_return_the_Int32_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_Int32
                    );
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_2_byte_Int32()
            {
                _initialPosition = 1;

                Test.Verify(
                    with_a_stream_positioned_at_a_2_byte_Int32,
                    when_asked_to_read_a_7_bit_variable_length_Int32,
                    should_return_the_Int32_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_Int32
                    );
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_3_byte_Int32()
            {
                _initialPosition = 1;

                Test.Verify(
                    with_a_stream_positioned_at_a_3_byte_Int32,
                    when_asked_to_read_a_7_bit_variable_length_Int32,
                    should_return_the_Int32_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_Int32
                    );
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_4_byte_Int32()
            {
                _initialPosition = 1;

                Test.Verify(
                    with_a_stream_positioned_at_a_4_byte_Int32,
                    when_asked_to_read_a_7_bit_variable_length_Int32,
                    should_return_the_Int32_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_Int32
                    );
            }

            private void should_return_the_Int32_at_Position()
            {
                _result.ShouldBeEqualTo(_expectedValue);
            }

            private void should_set_the_position_to_the_first_byte_after_the_Int32()
            {
                _stream.Position.ShouldBeEqualTo(_expectedPosition);
            }

            private void when_asked_to_read_a_7_bit_variable_length_Int32()
            {
                _stream.Position = _initialPosition;
                _result = _stream.Read7bitVariableLengthInt32();
            }

            private void with_a_stream_positioned_at_a_1_byte_Int32()
            {
                _initialPosition = 4;
                _expectedPosition = _initialPosition + 1;
                _expectedValue = 0x0c;
            }

            private void with_a_stream_positioned_at_a_2_byte_Int32()
            {
                _initialPosition = 3;
                _expectedPosition = _initialPosition + 2;
                _expectedValue = 0x668;
            }

            private void with_a_stream_positioned_at_a_3_byte_Int32()
            {
                _initialPosition = 2;
                _expectedPosition = _initialPosition + 3;
                _expectedValue = 0x33451;
            }

            private void with_a_stream_positioned_at_a_4_byte_Int32()
            {
                _initialPosition = 1;
                _expectedPosition = _initialPosition + 4;
                _expectedValue = 0x19A28FC;
            }
        }

        [TestFixture]
        public class When_asked_to_read_a_String
        {
            private byte[] _bytes;
            private string _expected;
            private int _initialPosition;
            private string _result;
            private MemoryStream _stream;

            [SetUp]
            public void BeforeEachTest()
            {
                _bytes = new byte[]
                {
                    0x05, (byte)'Y', (byte)'E', (byte)'S', 0x01
                };

                _stream = new MemoryStream(_bytes);
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_a_String()
            {
                _initialPosition = 1;
                _expected = "YES";

                Test.Verify(
                    with_a_stream_positioned_at_a_String,
                    when_asked_to_read_a_String,
                    should_return_the_String_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_String
                    );
            }

            private void should_return_the_String_at_Position()
            {
                _result.ShouldBeEqualTo(_expected);
            }

            private void should_set_the_position_to_the_first_byte_after_the_String()
            {
                _stream.Position.ShouldBeEqualTo(_initialPosition + _expected.Length);
            }

            private void when_asked_to_read_a_String()
            {
                _result = _stream.ReadString(_expected.Length);
            }

            private void with_a_stream_positioned_at_a_String()
            {
                _stream.Position = _initialPosition;
            }
        }

        [TestFixture]
        public class When_asked_to_read_a_String_having_a_7_bit_variable_length_Int32_prefix
        {
            private byte[] _bytes;
            private string _expected;
            private int _initialPosition;
            private int _numberOfBytesInEncodedStringLength;
            private string _result;
            private MemoryStream _stream;

            [SetUp]
            public void BeforeEachTest()
            {
                _bytes = new byte[]
                {
                    0x03, (byte)'Y', (byte)'E', (byte)'S', 0x01
                };

                _stream = new MemoryStream(_bytes);
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_a_String()
            {
                _numberOfBytesInEncodedStringLength = 1;
                _initialPosition = 0;
                _expected = "YES";

                Test.Verify(
                    with_a_stream_positioned_at_a_String,
                    when_asked_to_read_a_String,
                    should_return_the_String_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_String
                    );
            }

            private void should_return_the_String_at_Position()
            {
                _result.ShouldBeEqualTo(_expected);
            }

            private void should_set_the_position_to_the_first_byte_after_the_String()
            {
                _stream.Position.ShouldBeEqualTo(_initialPosition + _expected.Length + _numberOfBytesInEncodedStringLength);
            }

            private void when_asked_to_read_a_String()
            {
                _result = _stream.ReadStringHaving7bitVariableLengthInt32Prefix();
            }

            private void with_a_stream_positioned_at_a_String()
            {
                _stream.Position = _initialPosition;
            }
        }

        [TestFixture]
        public class When_asked_to_read_a_little_endian_Int32
        {
            private byte[] _bytes;
            private int _initialPosition;
            private int _result;
            private MemoryStream _stream;

            [SetUp]
            public void BeforeEachTest()
            {
                _bytes = new byte[]
                {
                    0x05, 0x04, 0x03, 0x02, 0x01
                };

                _stream = new MemoryStream(_bytes);
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_an_Int32()
            {
                _initialPosition = 1;

                Test.Verify(
                    with_a_stream_positioned_at_an_Int32,
                    when_asked_to_read_a_little_endian_Int32,
                    should_return_the_Int32_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_Int32
                    );
            }

            private void should_return_the_Int32_at_Position()
            {
                int expected = _bytes[_initialPosition]
                               | (_bytes[1 + _initialPosition] << 8)
                               | (_bytes[2 + _initialPosition] << 16)
                               | (_bytes[3 + _initialPosition] << 24);
                _result.ShouldBeEqualTo(expected);
            }

            private void should_set_the_position_to_the_first_byte_after_the_Int32()
            {
                _stream.Position.ShouldBeEqualTo(_initialPosition + sizeof(int));
            }

            private void when_asked_to_read_a_little_endian_Int32()
            {
                _result = _stream.ReadLEInt32();
            }

            private void with_a_stream_positioned_at_an_Int32()
            {
                _stream.Position = _initialPosition;
            }
        }

        [TestFixture]
        public class When_asked_to_read_a_little_endian_Short
        {
            private byte[] _bytes;
            private int _initialPosition;
            private short _result;
            private MemoryStream _stream;

            [SetUp]
            public void BeforeEachTest()
            {
                _bytes = new byte[]
                {
                    0x04, 0x03, 0x02, 0x01
                };

                _stream = new MemoryStream(_bytes);
            }

            [Test]
            public void Given_a_memory_stream_positioned_at_a_Short()
            {
                _initialPosition = 1;

                Test.Verify(
                    with_a_stream_positioned_at_a_Short,
                    when_asked_to_read_a_little_endian_Short,
                    should_return_the_Short_at_Position,
                    should_set_the_position_to_the_first_byte_after_the_Short
                    );
            }

            private void should_return_the_Short_at_Position()
            {
                short expected = (short)(_bytes[_initialPosition] | (_bytes[1 + _initialPosition] << 8));
                _result.ShouldBeEqualTo(expected);
            }

            private void should_set_the_position_to_the_first_byte_after_the_Short()
            {
                _stream.Position.ShouldBeEqualTo(_initialPosition + sizeof(short));
            }

            private void when_asked_to_read_a_little_endian_Short()
            {
                _result = _stream.ReadLEShort();
            }

            private void with_a_stream_positioned_at_a_Short()
            {
                _stream.Position = _initialPosition;
            }
        }
    }
}