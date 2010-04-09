using System;
using System.Diagnostics;

namespace FluentAssert
{
	public class TestGivenClauseWithoutActionContainerSource<T>
	{
		internal TestGivenClauseWithoutActionContainerSource()
		{
		}

		[DebuggerNonUserCode]
		public TestGivenClause<T> CreatedBy(Func<T> createActionContainer)
		{
			return new TestGivenClause<T>(new ActionContainerSource<T>
				{
					GetActionContainer = createActionContainer
				});
		}

		[DebuggerNonUserCode]
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