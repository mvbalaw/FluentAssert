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
	internal interface IParameterActionWrapper
	{
		string Description { get; }

		void Setup();
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ParameterActionWrapper : IParameterActionWrapper
	{
		private readonly Action _setup;

		internal ParameterActionWrapper(Action setup)
		{
			_setup = setup;
		}

		public void Setup()
		{
			_setup();
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ParameterActionWrapper<T> : IParameterActionWrapper
	{
		private readonly T _actionContainer;
		private readonly Action<T> _setup;

		internal ParameterActionWrapper(T actionContainer, Action<T> setup)
		{
			_actionContainer = actionContainer;
			_setup = setup;
		}

		public void Setup()
		{
			_setup(_actionContainer);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	internal class ParameterActionWrapper<T, TContext> : IParameterActionWrapper
	{
		private readonly T _actionContainer;
		private readonly TContext _context;
		private readonly Action<T, TContext> _setup;

		internal ParameterActionWrapper(T actionContainer, TContext context, Action<T, TContext> setup)
		{
			_actionContainer = actionContainer;
			_context = context;
			_setup = setup;
		}

		public void Setup()
		{
			_setup(_actionContainer, _context);
		}

		public string Description
		{
			get { return ActionDescriptionBuilder.BuildFor(_setup); }
		}
	}
}