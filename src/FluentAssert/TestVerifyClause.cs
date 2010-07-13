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
		private readonly ExceptionConfiguration _exceptionConfiguration;

		public TestVerifyClause()
			: this(new ExceptionConfiguration())
		{
		}

		public TestVerifyClause(ExceptionConfiguration exceptionConfiguration)
		{
			_exceptionConfiguration = exceptionConfiguration;
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

			Verify(steps, _exceptionConfiguration);
		}

		internal void Verify(List<ITestStep> steps)
		{
			Verify(steps, new ExceptionConfiguration());
		}

		private void Verify(List<ITestStep> steps, ExceptionConfiguration exceptionConfiguration)
		{
			var scenarioDescription = new StringBuilder();
			steps.ForEach(x => TestStepExecutor.Verify(scenarioDescription, x, exceptionConfiguration));
			if (_exceptionConfiguration.ExpectException)
			{
				Console.Error.WriteLine(scenarioDescription.ToString());

				throw new AssertionException(String.Format("Expected exception of type {0} was not thrown.",
				                                           _exceptionConfiguration.ExpectedExceptionType));
			}
		}
	}
}