//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System;
using System.Diagnostics;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestGivenClause<T>
	{
		private readonly ActionContainerSource<T> _actionContainerSource;

		internal TestGivenClause(ActionContainerSource<T> actionContainerSource)
		{
			_actionContainerSource = actionContainerSource;
		}

		public TestWhenClause<T> When(Action<T> actionUnderTest)
		{
			var actionContainer = _actionContainerSource.GetActionContainer();
			return new TestWhenClause<T>(actionContainer, new WhenActionWrapper<T>(actionContainer, actionUnderTest));
		}

		public TestWhenClause<T> When(Action actionUnderTest)
		{
			var actionContainer = _actionContainerSource.GetActionContainer();
			return new TestWhenClause<T>(actionContainer, new WhenActionWrapper(actionUnderTest));
		}

		public TestGivenClause<T, TContext> WithContext<TContext>(TContext context)
		{
			var actionContainerSource = new ActionContainerSource<T, TContext>
			                            {
				                            GetActionContainer = delegate { return _actionContainerSource.GetActionContainer(); }
			                            };
			return new TestGivenClause<T, TContext>(actionContainerSource, context);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestGivenClause<T, TContext>
	{
		private readonly ActionContainerSource<T, TContext> _actionContainerSource;
		private readonly TContext _context;

		internal TestGivenClause(ActionContainerSource<T, TContext> actionContainerSource, TContext context)
		{
			_actionContainerSource = actionContainerSource;
			_context = context;
		}

		public TestWhenClause<T, TContext> When(Action<T, TContext> actionUnderTest)
		{
			var actionContainer = _actionContainerSource.GetActionContainer(_context);
			return new TestWhenClause<T, TContext>(actionContainer,
				new WhenActionWrapper<T, TContext>(actionContainer, _context, actionUnderTest),
				_context);
		}

		public TestWhenClause<T, TContext> When(Action<T> actionUnderTest)
		{
			var actionContainer = _actionContainerSource.GetActionContainer(_context);
			return new TestWhenClause<T, TContext>(actionContainer,
				new WhenActionWrapper<T>(actionContainer, actionUnderTest),
				_context);
		}

		public TestWhenClause<T, TContext> When(Action actionUnderTest)
		{
			var actionContainer = _actionContainerSource.GetActionContainer(_context);
			return new TestWhenClause<T, TContext>(actionContainer,
				new WhenActionWrapper(actionUnderTest),
				_context);
		}
	}
}