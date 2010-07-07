using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestVerifyClause
	{
		private static ITestStep TestStepCreator(IEnumerable<ITestStepCreator> testStepCreators, Action x)
		{
			var testStepCreator = testStepCreators.First(y => y.IsMatch(x));
			return testStepCreator.CreateFrom(x);
		}

		public void Verify(params Action[] actions)
		{
			var testStepCreators = new ITestStepCreator[] { new WithTestStep(), new WhenTestStep(), new ExpectTestStep(), new ShouldTestStep(), new DefaultTestStep() };
			var steps = actions.Select(x => TestStepCreator(testStepCreators, x)).ToList();

			Verify(steps);
		}

		internal void Verify(List<ITestStep> steps)
		{
			var scenarioDescription = new StringBuilder();
			steps.ForEach(x => TestStepExecutor.Verify(scenarioDescription, x));
		}
	}
}