using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FluentAssert
{
	internal class TestStep
	{
		public Action Action;
		public string Description;
		public string FailureSuffix;
		public string SuccessSuffix;
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal static class TestRunner
	{
		private static void DoStep(StringBuilder scenarioDescription, TestStep testStep)
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

		public static void Verify(string actionDescription,
		                          IEnumerable<IParameterActionWrapper> parameterActions,
		                          Action action,
		                          IEnumerable<IDependencyActionWrapper> dependencyActions,
		                          IEnumerable<IAssertionActionWrapper> assertions)
		{
			var steps = parameterActions
				.Select(arrange => new TestStep
					{
						Description = "WITH " + arrange.Description,
						Action = arrange.Setup,
						FailureSuffix = " - FAILED",
						SuccessSuffix = ""
					})
				.ToList();

			steps.AddRange(
				dependencyActions.Select(assertion => new TestStep
				{
					Description = "EXPECT " +assertion.Description,
					Action = assertion.Verify,
					FailureSuffix = " - FAILED",
					SuccessSuffix = ""
				}));

			steps.Add(new TestStep
				{
					Description = "WHEN " + actionDescription,
					Action = action,
					FailureSuffix = " - FAILED",
					SuccessSuffix = ""
				});

			steps.AddRange(
				assertions.Select(assertion => new TestStep
					{
						Description = "SHOULD " + assertion.Description,
						Action = assertion.Verify,
						FailureSuffix = " - FAILED",
						SuccessSuffix = " - PASSED"
					}));

			var scenarioDescription = new StringBuilder();
			steps.ForEach(x => DoStep(scenarioDescription, x));
		}
	}
}