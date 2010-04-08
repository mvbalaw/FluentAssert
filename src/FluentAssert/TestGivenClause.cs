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
	}
}