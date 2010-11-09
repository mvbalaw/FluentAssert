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
	public class TestGivenClauseWithoutActionContainerSource<T>
	{
		internal TestGivenClauseWithoutActionContainerSource()
		{
		}

		public TestGivenClause<T> CreatedBy(Func<T> createActionContainer)
		{
			return new TestGivenClause<T>(new ActionContainerSource<T>
			{
				GetActionContainer = createActionContainer
			});
		}

		public TestGivenClause<T, TContext> CreatedBy<TContext>(Func<TContext, T> createActionContainer, TContext context)
		{
			return new TestGivenClause<T, TContext>(new ActionContainerSource<T, TContext>
			{
				GetActionContainer = createActionContainer
			},
			                                        context);
		}
	}
}