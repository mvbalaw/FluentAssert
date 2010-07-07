using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class TestStepExecutor
	{
		public static void Verify(StringBuilder scenarioDescription, ITestStep testStep)
		{
			scenarioDescription.Append(testStep.Description);
			try
			{
				testStep.Action();
				scenarioDescription.AppendLine(testStep.SuccessSuffix);
			}
			catch (Exception)
			{
				scenarioDescription.AppendLine(testStep.FailureSuffix);
				Console.Error.WriteLine(scenarioDescription.ToString());
				throw;
			}
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal static class TestRunner
	{
		public static void Verify(string actionDescription,
		                          IEnumerable<IParameterActionWrapper> parameterActions,
		                          Action action,
		                          IEnumerable<IDependencyActionWrapper> dependencyActions,
		                          IEnumerable<IAssertionActionWrapper> assertions)
		{
			var steps = parameterActions
				.Select(arrange => new WithTestStep(arrange.Setup, arrange.Description))
				.Cast<ITestStep>()
				.ToList();

			steps.AddRange(
				dependencyActions
					.Select(assertion => new ExpectTestStep(assertion.Verify, assertion.Description))
					.Cast<ITestStep>()
				);

			steps.Add(new WhenTestStep(action, actionDescription));

			steps.AddRange(
				assertions.Select(assertion => new ShouldTestStep(assertion.Verify, assertion.Description))
					.Cast<ITestStep>()
				);

			new TestVerifyClause().Verify(steps);
		}
	}
}