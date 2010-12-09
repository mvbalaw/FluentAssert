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
			private byte[] _bytes;
			private ExceptionRewriter _rewriter;
			private Exception _result;
			private string _expectedStackTrace;

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
				Console.WriteLine(_result.StackTrace);
				_result.StackTrace.ShouldBeEqualTo(_expectedStackTrace);
			}

			private void when_asked_to_rewrite_the_stacktrace()
			{
				var exception = GetException();
				_result = _rewriter.RewriteStacktrace(exception);
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
				_expectedStackTrace = @"   at FluentAssert.Test.Verify(Action[] actions) in D:\projects\git-fluentassert\src\FluentAssert\Test.cs:line 43";
			}

			private void with_an_AssertionException()
			{
				_bytes = EmbeddedResource.Read("AssertionException.bin");
				_expectedStackTrace = @"   at NUnit.Framework.Assert.That(Object actual, IResolveConstraint expression, String message, Object[] args)
   at FluentAssert.Tests.AssertExtensionsTests.When_asserting_that_a_boolean_should_be_false_with_a_Func_to_get_the_specific_error_message.should_throw_a_ShouldBeFalseAssertionException() in D:\projects\git-fluentassert\src\FluentAssert.Tests\AssertExtensionsTests.cs:line 158
   at FluentAssert.Test.Verify(Action[] actions) in D:\projects\git-fluentassert\src\FluentAssert\Test.cs:line 43";
			}

			private void with_a_NotImplementedException()
			{
				_bytes = EmbeddedResource.Read("NotImplementedException.bin");
				_expectedStackTrace = @"   at FluentAssert.BinarySerializationParser.Parse(Byte[] input) in D:\projects\git-fluentassert\src\FluentAssert\BinarySerializationParser.cs:line 13
   at FluentAssert.Tests.BinarySerializationParserTests.When_asked_to_parse_binary_serialized_data.when_asked_to_parse() in D:\projects\git-fluentassert\src\FluentAssert.Tests\BinarySerializationParserTests.cs:line 83
   at FluentAssert.Test.Verify(Action[] actions) in D:\projects\git-fluentassert\src\FluentAssert\Test.cs:line 56
   at FluentAssert.Tests.BinarySerializationParserTests.When_asked_to_parse_binary_serialized_data.Given_a_serialized_NotImplementedException() in D:\projects\git-fluentassert\src\FluentAssert.Tests\BinarySerializationParserTests.cs:line 43";
			}

			private void with_a_ShouldBeEqualAssertionException()
			{
				_bytes = EmbeddedResource.Read("ShouldBeEqualAssertionException.bin");
				_expectedStackTrace = @"   at FluentAssert.AssertExtensions.ShouldBeEqualTo[T](T item, T expected) in d:\projects\git-fluentassert\src\FluentAssert\AssertExtensions.cs:line 60
   at SuitSystem.Web.Tests.TemplateGeneration.TemplateServiceTests.When_asked_to_generate_a_file_path_for_a_template.Return_the_file_path() in D:\projects\Enterprise\WorkingCopy\src\SuitSystem.Web.Tests\TemplateGeneration\TemplateServiceTests.cs:line 111
   at FluentAssert.TestShouldClause`1.Verify() in d:\projects\git-fluentassert\src\FluentAssert\TestShouldClause.cs:line 78";
			}
		}
	}
}