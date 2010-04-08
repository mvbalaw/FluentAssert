using System;
using System.Collections.Generic;

namespace FluentAssert
{
	public class TestWhenClause<T>
	{
		private readonly T _actionContainer;
		private readonly Action<T> _actionUnderTest;
		private readonly IList<Action<T>> _assertions = new List<Action<T>>();
		private readonly IList<Action<T>> _initializationsForActionParameters;

		public TestWhenClause(T actionContainer, Action<T> actionUnderTest, IList<Action<T>> initializationsForActionParameters)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_initializationsForActionParameters = initializationsForActionParameters;
		}

		public TestWhenClause<T> Should(Action<T> assertion)
		{
			_assertions.Add(assertion);
			return this;
		}

		public void Verify()
		{
			foreach (var arrange in _initializationsForActionParameters)
			{
				arrange(_actionContainer);
			}

			_actionUnderTest(_actionContainer);

			foreach (var assert in _assertions)
			{
				assert(_actionContainer);
			}
		}
	}
}