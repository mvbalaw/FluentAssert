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