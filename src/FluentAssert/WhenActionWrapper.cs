using System;
using System.Diagnostics;

namespace FluentAssert
{
	internal interface IWhenActionWrapper
	{
		void Act();
	}

	internal class WhenActionWrapper : IWhenActionWrapper
	{
		private readonly Action _actionUnderTest;

		internal WhenActionWrapper(Action actionUnderTest)
		{
			_actionUnderTest = actionUnderTest;
		}

		[DebuggerNonUserCode]
		public void Act()
		{
			_actionUnderTest();
		}
	}

	internal class WhenActionWrapper<T> : IWhenActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T> _actionUnderTest;

		internal WhenActionWrapper(T actionContainer, Action<T> actionUnderTest)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
		}

		[DebuggerNonUserCode]
		public void Act()
		{
			_actionUnderTest(_actionContainer);
		}
	}

	internal class WhenActionWrapper<T, TContext> : IWhenActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T, TContext> _actionUnderTest;
		private readonly TContext _context;

		internal WhenActionWrapper(T actionContainer, TContext context, Action<T, TContext> actionUnderTest)
		{
			_actionContainer = actionContainer;
			_context = context;
			_actionUnderTest = actionUnderTest;
		}

		[DebuggerNonUserCode]
		public void Act()
		{
			_actionUnderTest(_actionContainer, _context);
		}
	}
}