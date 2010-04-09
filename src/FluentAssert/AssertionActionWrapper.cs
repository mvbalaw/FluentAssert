using System;
using System.Diagnostics;

namespace FluentAssert
{
	internal interface IAssertionActionWrapper
	{
		[DebuggerNonUserCode]
		void Verify();
	}

	internal class AssertionActionWrapper : IAssertionActionWrapper
	{
		private readonly Action _assert;

		internal AssertionActionWrapper(Action assert)
		{
			_assert = assert;
		}

		[DebuggerStepThrough]
		public void Verify()
		{
			_assert();
		}
	}

	internal class AssertionActionWrapper<T> : IAssertionActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T> _assert;

		internal AssertionActionWrapper(T actionContainer, Action<T> assert)
		{
			_actionContainer = actionContainer;
			_assert = assert;
		}

		[DebuggerStepThrough]
		public void Verify()
		{
			_assert(_actionContainer);
		}
	}

	internal class AssertionActionWrapper<T, TContext> : IAssertionActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T, TContext> _assert;
		private readonly TContext _context;

		internal AssertionActionWrapper(T actionContainer, TContext context, Action<T, TContext> assert)
		{
			_actionContainer = actionContainer;
			_context = context;
			_assert = assert;
		}

		[DebuggerStepThrough]
		public void Verify()
		{
			_assert(_actionContainer, _context);
		}
	}
}