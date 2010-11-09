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
	internal interface IWhenActionWrapper
	{
		string Description { get; }
		void Act();
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class WhenActionWrapper : IWhenActionWrapper
	{
		private readonly Action _actionUnderTest;

		internal WhenActionWrapper(Action actionUnderTest)
		{
			_actionUnderTest = actionUnderTest;
		}

		public void Act()
		{
			_actionUnderTest();
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_actionUnderTest); }
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class WhenActionWrapper<T> : IWhenActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T> _actionUnderTest;

		internal WhenActionWrapper(T actionContainer, Action<T> actionUnderTest)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
		}

		public void Act()
		{
			_actionUnderTest(_actionContainer);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_actionUnderTest); }
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
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

		public void Act()
		{
			_actionUnderTest(_actionContainer, _context);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_actionUnderTest); }
		}
	}
}