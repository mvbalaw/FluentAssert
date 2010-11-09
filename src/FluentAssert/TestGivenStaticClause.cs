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
	public class TestGivenStaticClause
	{
		public TestWhenStaticClause When(Action actionUnderTest)
		{
			return new TestWhenStaticClause(actionUnderTest);
		}

		public TestGivenStaticClause<TContext> WithContext<TContext>(TContext context)
		{
			return new TestGivenStaticClause<TContext>(context);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestGivenStaticClause<TContext>
	{
		private readonly TContext _context;

		internal TestGivenStaticClause(TContext context)
		{
			_context = context;
		}

		public TestWhenStaticClause<TContext> When(Action<TContext> actionUnderTest)
		{
			return new TestWhenStaticClause<TContext>(new WhenActionWrapper<TContext>(_context, actionUnderTest), _context);
		}
	}
}