using System;

namespace FluentAssert
{
	internal class ActionContainerSource<T>
	{
		public Func<T> GetActionContainer { get; set; }
	}

	internal class ActionContainerSource<T, TContext>
	{
		public Func<TContext, T> GetActionContainer { get; set; }
	}
}