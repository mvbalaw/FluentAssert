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
	internal interface IAssertionActionWrapper
	{
		string Description { get; }
		void Verify();
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class AssertionActionWrapper : IAssertionActionWrapper
	{
		private readonly Action _assert;

		internal AssertionActionWrapper(Action assert)
		{
			_assert = assert;
		}

		public void Verify()
		{
			_assert();
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_assert); }
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class AssertionActionWrapper<T> : IAssertionActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T> _assert;

		internal AssertionActionWrapper(T actionContainer, Action<T> assert)
		{
			_actionContainer = actionContainer;
			_assert = assert;
		}

		public void Verify()
		{
			_assert(_actionContainer);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_assert); }
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
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

		public void Verify()
		{
			_assert(_actionContainer, _context);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_assert); }
		}
	}
}