using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal static class TestRunner
	{
		public static void Verify(string actionDescription,
		                          IEnumerable<IParameterActionWrapper> initializationsForActionParameters,
		                          Action action,
		                          IEnumerable<IAssertionActionWrapper> assertions)
		{
			var scenarioDescription = new StringBuilder();
			foreach (var arrange in initializationsForActionParameters)
			{
				scenarioDescription.AppendLine("WITH " + arrange.Description);
				arrange.Setup();
			}

			scenarioDescription.AppendLine("WHEN " + actionDescription);
			action();

			foreach (var assertion in assertions)
			{
				scenarioDescription.Append("SHOULD " + assertion.Description);
				try
				{
					assertion.Verify();
					scenarioDescription.AppendLine(" - PASSED");
				}
				catch (Exception)
				{
					scenarioDescription.AppendLine(" - FAILED");
					Console.Error.WriteLine(scenarioDescription.ToString());
					throw;
				}
			}
		}
	}
}