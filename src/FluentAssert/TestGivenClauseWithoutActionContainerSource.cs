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