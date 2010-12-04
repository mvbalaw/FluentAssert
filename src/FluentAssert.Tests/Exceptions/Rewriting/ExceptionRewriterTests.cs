using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using FluentAssert.Exceptions.Rewriting;

using NUnit.Framework;

namespace FluentAssert.Tests.Exceptions.Rewriting
{
	public class ExceptionRewriterTests
	{
		[TestFixture]
		public class When_asked_to_rewrite_the_stacktrace
		{
			private const string StartRemovingAt = "FluentAssert";
			private const string StopRemovingAt = "FluentAssert.Test";
			private byte[] _bytes;
			private ExceptionRewriter _rewriter;
			private Exception _result;
			private int _stackTracePosition;

			[SetUp]
			public void BeforeEachTest()
			{
				_rewriter = new ExceptionRewriter();
			}

			[Test]
			public void Given_an_AssertionException()
			{
				Test.Verify(
					with_an_AssertionException,
					when_asked_to_rewrite_the_stacktrace,
					should_return_an_Exception_that_has_a_rewritten_stacktrace
					);
			}

			[Test]
			public void Given_an_ArgumentException()
			{
				Test.Verify(
					with_an_ArgumentException,
					when_asked_to_rewrite_the_stacktrace,
					should_return_an_Exception_that_has_a_rewritten_stacktrace
					);
			}

			[Test]
			public void Given_a_NotImplementedException()
			{
				Test.Verify(
					with_a_NotImplementedException,
					when_asked_to_rewrite_the_stacktrace,
					should_return_an_Exception_that_has_a_rewritten_stacktrace
					);
			}

			[Test]
			public void Given_a_ShouldBeEqualAssertionException()
			{
				Test.Verify(
					with_a_ShouldBeEqualAssertionException,
					when_asked_to_rewrite_the_stacktrace,
					should_return_an_Exception_that_has_a_rewritten_stacktrace
					);
			}


			private void should_return_an_Exception_that_has_a_rewritten_stacktrace()
			{
				var stream = new MemoryStream(_bytes)
				{
					Position = _stackTracePosition
				};
				var stackTrace = stream.ReadStringHaving7bitVariableLengthInt32Prefix();
				var start = stackTrace.IndexOf("  at "+StartRemovingAt);
				start.ShouldBeGreaterThan(0);
				var end = stackTrace.LastIndexOf("  at "+StopRemovingAt);
				end.ShouldBeGreaterThan(start);
				stackTrace = stackTrace.Remove(start, end - start);

				_result.StackTrace.ShouldBeEqualTo(stackTrace);
			}

			private void when_asked_to_rewrite_the_stacktrace()
			{
				var exception = GetException();
				_result = _rewriter.RewriteStacktrace(exception, StartRemovingAt, StopRemovingAt);
			}

			public Exception GetException()
			{
				var bf = new BinaryFormatter();
				var stream = new MemoryStream(_bytes)
				{
					Position = 0
				};
				var result = (Exception)bf.Deserialize(stream);
				stream.Close();
				return result;
			}

			private void with_an_ArgumentException()
			{
				_bytes = EmbeddedResource.Read("ArgumentException.bin");
				_stackTracePosition = 0x15b;
			}

			private void with_an_AssertionException()
			{
				_bytes = EmbeddedResource.Read("AssertionException.bin");
				_stackTracePosition = 0x208;
			}

			private void with_a_NotImplementedException()
			{
				_bytes = EmbeddedResource.Read("NotImplementedException.bin");
				_stackTracePosition = 0x159;
			}

			private void with_a_ShouldBeEqualAssertionException()
			{
				_bytes = EmbeddedResource.Read("ShouldBeEqualAssertionException.bin");
				_stackTracePosition = 0x1cc;
			}
		}
	}
}