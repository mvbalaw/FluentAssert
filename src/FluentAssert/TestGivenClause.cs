using System;

namespace FluentAssert
{
	public class TestGivenClause<T>
	{
		private readonly T _actionContainer;

		public TestGivenClause(T actionContainer)
		{
			_actionContainer = actionContainer;
		}

		public TestWithClause<T> When(Action<T> actionUnderTest)
		{
			return new TestWithClause<T>(_actionContainer, actionUnderTest);
		}

		public TestGivenClause<T, TContext> WithContext<TContext>(TContext context)
		{
			return new TestGivenClause<T, TContext>(_actionContainer, context);
		}
	}

	public class TestGivenClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly TContext _context;

		public TestGivenClause(T actionContainer, TContext context)
		{
			_actionContainer = actionContainer;
			_context = context;
		}

		public TestWithClause<T, TContext> When(Action<T, TContext> actionUnderTest)
		{
			return new TestWithClause<T, TContext>(_actionContainer, actionUnderTest, _context);
		}
	}
}