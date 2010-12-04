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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

using FluentAssert.Exceptions.Rewriting;

using NUnit.Framework;

namespace FluentAssert.Tests
{
    public class BinarySerializationParserTests
    {
        [TestFixture]
        public class When_asked_to_parse_binary_serialized_data
        {
            private int _expectedOffset;
            private byte[] _input;
            private int _result;

            [Test]
            public void Deserialize_ArgumentNullException()
            {
                var bf = new BinaryFormatter();
                var stream = new MemoryStream(ReadEmbeddedResource("ArgumentException.bin"));
                var ex = (Exception)bf.Deserialize(stream);
                stream.Close();
            }

            [Test]
            public void Given_a_serialized_ArgumentException()
            {
                _expectedOffset = 0x156;

                Test.Verify(
                    with_a_serialized_ArgumentException,
                    when_asked_to_parse,
                    should_return_the_expected_offset
                    );
            }

            [Test]
            public void Given_a_serialized_AssertionException()
            {
                _expectedOffset = 0x203;

                Test.Verify(
                    with_a_serialized_AssertionException,
                    when_asked_to_parse,
                    should_return_the_expected_offset
                    );
            }

            [Test]
            public void Given_a_serialized_NotImplementedException()
            {
                _expectedOffset = 0x154;
                Test.Verify(
                    with_a_serialized_NotImplementedException,
                    when_asked_to_parse,
                    should_return_the_expected_offset
                    );
            }

            [Test]
            public void Given_a_serialized_ShouldBeEqualAssertionException()
            {
                _expectedOffset = 0x1c7;

                Test.Verify(
                    with_a_serialized_ShouldBeEqualAssertionException,
                    when_asked_to_parse,
                    should_return_the_expected_offset
                    );
            }

            private static byte[] ReadEmbeddedResource(string resourceName)
            {
                var asm = Assembly.GetExecutingAssembly();
                string name = asm.GetManifestResourceNames().First(x => x.EndsWith("." + resourceName));
                using (var stream = asm.GetManifestResourceStream(name))
                {
// ReSharper disable PossibleNullReferenceException
                    var bytes = new byte[stream.Length];
// ReSharper restore PossibleNullReferenceException
                    stream.Read(bytes, 0, bytes.Length);
                    return bytes;
                }
            }

            private void should_return_the_expected_offset()
            {
                _result.ShouldBeEqualTo(_expectedOffset);
            }

            private void when_asked_to_parse()
            {
                _result = new BinarySerializationParser().LocateStackTrace(_input);
            }

            private void with_a_serialized_ArgumentException()
            {
                _input = ReadEmbeddedResource("ArgumentException.bin");
            }

            private void with_a_serialized_AssertionException()
            {
                _input = ReadEmbeddedResource("AssertionException.bin");
            }

            private void with_a_serialized_NotImplementedException()
            {
                _input = ReadEmbeddedResource("NotImplementedException.bin");
            }

            private void with_a_serialized_ShouldBeEqualAssertionException()
            {
                _input = ReadEmbeddedResource("ShouldBeEqualAssertionException.bin");
            }
        }
    }
}