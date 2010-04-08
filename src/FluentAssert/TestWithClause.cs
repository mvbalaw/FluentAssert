using System;
using System.Collections.Generic;

namespace FluentAssert
{
	public class TestWithClause<T>
	{
		private readonly T _actionContainer;
		private readonly Action<T> _actionUnderTest;
		private readonly IList<Action<T>> _initializationsForActionParameters = new List<Action<T>>();

		public TestWithClause(T actionContainer, Action<T> actionUnderTest)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
		}

		public TestWhenClause<T> Should(Action<T> assertion)
		{
			return new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.Should(assertion);
		}

		public TestWithClause<T> With(Action<T> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(initializationForActionParameter);
			return this;
		}
	}
}