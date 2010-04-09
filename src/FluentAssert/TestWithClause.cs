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

		public void ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>();
		}

		public void ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWithClause<T> With(Action<T> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(initializationForActionParameter);
			return this;
		}
	}

	public class TestWithClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly Action<T, TContext> _actionUnderTest;
		private readonly TContext _context;
		private readonly IList<Action<T, TContext>> _initializationsForActionParameters = new List<Action<T, TContext>>();

		public TestWithClause(T actionContainer, Action<T, TContext> actionUnderTest, TContext context)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_context = context;
		}

		public TestWhenClause<T, TContext> Should(Action<T, TContext> assertion)
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		public void ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters, _context)
				.ShouldThrowException<TExceptionType>();
		}

		public void ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters, _context)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWithClause<T, TContext> With(Action<T, TContext> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(initializationForActionParameter);
			return this;
		}
	}
}