using System;
using System.Diagnostics;
using System.Globalization;

namespace FluentAssert
{
	internal interface ITestStep
	{
		Action Action { get; set; }
		string Description { get; set; }
		string FailureSuffix { get; set; }
		string SuccessSuffix { get; set; }
	}

	internal interface ITestStepCreator
	{
		ITestStep CreateFrom(Action action);
		bool IsMatch(Action action);
	}

	internal class TestStep : ITestStep
	{
		public Action Action { get; set; }
		public string Description { get; set; }
		public string FailureSuffix { get; set; }
		public string SuccessSuffix { get; set; }

		protected static string BuildDescription(Action action, string actionTypeDescription)
		{
			return actionTypeDescription + " " + ActionDescriptionBuilder.BuildFor(action, actionTypeDescription);
		}

		protected static bool IsMatch(Action action, string actionTypeDescription)
		{
			return action.Method.Name.StartsWith(actionTypeDescription, true, CultureInfo.CurrentCulture);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class WithTestStep : TestStep, ITestStepCreator
	{
		private const string ActionTypeDescription = "WITH";

		public WithTestStep(Action action)
			: this(action, BuildDescription(action, ActionTypeDescription))
		{
		}

		public WithTestStep(Action action, string description)
			: this()
		{
			Description = description;
			Action = action;
		}

		public WithTestStep()
		{
			FailureSuffix = " - FAILED";
			SuccessSuffix = "";
		}

		public bool IsMatch(Action action)
		{
			return IsMatch(action, ActionTypeDescription);
		}

		public ITestStep CreateFrom(Action action)
		{
			return new WithTestStep(action);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ExpectTestStep : TestStep, ITestStepCreator
	{
		private const string ActionTypeDescription = "EXPECT";

		public ExpectTestStep(Action action)
			: this(action, BuildDescription(action, ActionTypeDescription))
		{
		}

		public ExpectTestStep(Action action, string description)
			: this()
		{
			Description = description;
			Action = action;
		}

		public ExpectTestStep()
		{
			FailureSuffix = " - FAILED";
			SuccessSuffix = "";
		}

		public bool IsMatch(Action action)
		{
			return IsMatch(action, ActionTypeDescription);
		}

		public ITestStep CreateFrom(Action action)
		{
			return new ExpectTestStep(action);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class WhenTestStep : TestStep, ITestStepCreator
	{
		private const string ActionTypeDescription = "WHEN";

		public WhenTestStep(Action action)
			: this(action, BuildDescription(action, ActionTypeDescription))
		{
		}

		public WhenTestStep(Action action, string description)
			: this()
		{
			Description = description;
			Action = action;
		}

		public WhenTestStep()
		{
			FailureSuffix = " - FAILED";
			SuccessSuffix = "";
		}

		public bool IsMatch(Action action)
		{
			return IsMatch(action, ActionTypeDescription);
		}

		public ITestStep CreateFrom(Action action)
		{
			return new WhenTestStep(action);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ShouldTestStep : TestStep, ITestStepCreator
	{
		private const string ActionTypeDescription = "SHOULD";

		public ShouldTestStep(Action action)
			: this(action, BuildDescription(action, ActionTypeDescription))
		{
		}

		public ShouldTestStep(Action action, string description)
			: this()
		{
			Description = description;
			Action = action;
		}

		public ShouldTestStep()
		{
			FailureSuffix = " - FAILED";
			SuccessSuffix = " - PASSED";
		}

		public bool IsMatch(Action action)
		{
			return IsMatch(action, ActionTypeDescription);
		}

		public ITestStep CreateFrom(Action action)
		{
			return new ShouldTestStep(action);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class DefaultTestStep : TestStep, ITestStepCreator
	{
		public DefaultTestStep(Action action)
			: this()
		{
			Description = ActionDescriptionBuilder.BuildFor(action);
			Action = action;
		}

		public DefaultTestStep()
		{
			FailureSuffix = " - FAILED";
			SuccessSuffix = " - PASSED";
		}

		public bool IsMatch(Action action)
		{
			return true;
		}

		public ITestStep CreateFrom(Action action)
		{
			return new DefaultTestStep(action);
		}
	}
}