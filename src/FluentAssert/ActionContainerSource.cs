using System;
using System.Diagnostics;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ActionContainerSource<T>
	{
		public Func<T> GetActionContainer { get; set; }
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ActionContainerSource<T, TContext>
	{
		public Func<TContext, T> GetActionContainer { get; set; }
	}
}