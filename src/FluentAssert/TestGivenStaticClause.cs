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