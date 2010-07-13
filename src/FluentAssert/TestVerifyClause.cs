using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestVerifyClause
	{
		private readonly bool _expectException;
		private readonly bool _expectExceptionMessage;
		private readonly string _expectedExceptionMessage;
		private readonly Type _expectedExceptionType;

		public TestVerifyClause()
		{
			_expectException = false;
			_expectExceptionMessage = false;
		}

		internal TestVerifyClause(Type expectedExceptionType)
		{
			_expectException = true;
			_expectExceptionMessage = false;
			_expectedExceptionType = expectedExceptionType;
		}

		internal TestVerifyClause(Type expectedExceptionType, string expectedExceptionMessage)
		{
			_expectException = true;
			_expectExceptionMessage = true;
			_expectedExceptionType = expectedExceptionType;
			_expectedExceptionMessage = expectedExceptionMessage;
		}

		private static ITestStep TestStepCreator(IEnumerable<ITestStepCreator> testStepCreators, Action x)
		{
			var testStepCreator = testStepCreators.First(y => y.IsMatch(x));
			return testStepCreator.CreateFrom(x);
		}

		public void Verify(params Action[] actions)
		{
			var testStepCreators = new ITestStepCreator[] { new WithTestStep(), new WhenTestStep(), new ExpectTestStep(), new ShouldTestStep(), new DefaultTestStep() };
			var steps = actions.Select(x => TestStepCreator(testStepCreators, x)).ToList();

			try
			{
				Verify(steps);
			}
			catch (Exception e)
			{
				if (!_expectException)
				{
					throw;
				}
				var exceptionType = e.GetType();
				if (exceptionType != _expectedExceptionType)
				{
					throw new AssertionException(String.Format("Expected exception of type {0} but caught type {1}",
					                                           _expectedExceptionType,
					                                           exceptionType),
					                             e);
				}
				if (_expectExceptionMessage)
				{
					if (e.Message != _expectedExceptionMessage)
					{
						throw new AssertionException(String.Format("Expected exception message '{0}' but had '{1}'",
						                                           _expectedExceptionMessage,
						                                           e.Message),
						                             e);
					}
				}
			}
		}

		internal void Verify(List<ITestStep> steps)
		{
			var scenarioDescription = new StringBuilder();
			steps.ForEach(x => TestStepExecutor.Verify(scenarioDescription, x));
		}
	}
}