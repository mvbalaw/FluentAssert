using System;
using System.Diagnostics;

namespace FluentAssert
{
	internal interface IDependencyActionWrapper
	{
		string Description { get; }

		void Verify();
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class DependencyActionWrapper : IDependencyActionWrapper
	{
		private readonly Action _setup;

		internal DependencyActionWrapper(Action setup)
		{
			_setup = setup;
		}

		public void Verify()
		{
			_setup();
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}
}