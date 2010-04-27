using System;
using System.Diagnostics;

namespace FluentAssert
{
	public class TestGivenStaticClause
	{
		[DebuggerNonUserCode]
		public TestWithStaticClause When(Action actionUnderTest)
		{
			return new TestWithStaticClause(actionUnderTest);
		}

		[DebuggerNonUserCode]
		public TestGivenStaticClause<TContext> WithContext<TContext>(TContext context)
		{
			return new TestGivenStaticClause<TContext>(context);
		}
	}

	public class TestGivenStaticClause<TContext>
	{
		private readonly TContext _context;

		internal TestGivenStaticClause(TContext context)
		{
			_context = context;
		}

		[DebuggerNonUserCode]
		public TestWithStaticClause<TContext> When(Action<TContext> actionUnderTest)
		{
			return new TestWithStaticClause<TContext>(new WhenActionWrapper<TContext>(_context, actionUnderTest), _context);
		}
	}
}