using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace FluentAssert
{
	public class TestWhenClause<T>
	{
		private readonly T _actionContainer;
		private readonly Action<T> _actionUnderTest;
		private readonly IList<Action<T>> _assertions = new List<Action<T>>();
		private readonly IList<Action<T>> _initializationsForActionParameters;
		private Action<T> _performAction;

		public TestWhenClause(T actionContainer, Action<T> actionUnderTest, IList<Action<T>> initializationsForActionParameters)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_initializationsForActionParameters = initializationsForActionParameters;
			_performAction = (T item) => _actionUnderTest(item);
		}

		public TestWhenClause<T> Should(Action<T> assertion)
		{
			_assertions.Add(assertion);
			return this;
		}

		public void ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = (T item) => Assert.Throws<TExceptionType>(() => _actionUnderTest(item));
			Verify();
		}

		public void ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = (T item) => Assert.Throws<TExceptionType>(() => _actionUnderTest(item), message);
			Verify();
		}

		public void Verify()
		{
			foreach (var arrange in _initializationsForActionParameters)
			{
				arrange(_actionContainer);
			}

			_performAction(_actionContainer);

			foreach (var assert in _assertions)
			{
				assert(_actionContainer);
			}
		}
	}

	public class TestWhenClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly Action<T, TContext> _actionUnderTest;
		private readonly IList<Action<T, TContext>> _assertions = new List<Action<T, TContext>>();
		private readonly TContext _context;
		private readonly IList<Action<T, TContext>> _initializationsForActionParameters;
		private Action<T, TContext> _performAction;

		public TestWhenClause(T actionContainer, Action<T, TContext> actionUnderTest, IList<Action<T, TContext>> initializationsForActionParameters, TContext context)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_initializationsForActionParameters = initializationsForActionParameters;
			_context = context;
			_performAction = (T item, TContext testContext) => _actionUnderTest(item, testContext);
		}

		public TestWhenClause<T, TContext> Should(Action<T, TContext> assertion)
		{
			_assertions.Add(assertion);
			return this;
		}

		public void ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = (T item, TContext testContext) => Assert.Throws<TExceptionType>(() => _actionUnderTest(item, testContext));
			Verify();
		}

		public void ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = (T item, TContext testContext) => Assert.Throws<TExceptionType>(() => _actionUnderTest(item, testContext), message);
			Verify();
		}

		public void Verify()
		{
			foreach (var arrange in _initializationsForActionParameters)
			{
				arrange(_actionContainer, _context);
			}

			_performAction(_actionContainer, _context);

			foreach (var assert in _assertions)
			{
				assert(_actionContainer, _context);
			}
		}
	}
}