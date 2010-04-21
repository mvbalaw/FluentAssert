using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FluentAssert
{
	public class TestWithClause<T>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;

		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters =
			new List<IParameterActionWrapper>();

		internal TestWithClause(T actionContainer, IWhenActionWrapper actionUnderTest)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T> Should(Action<T> assertion)
		{
			return new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T> Should(Action assertion)
		{
			return new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>();
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestWhenClause<T>(_actionContainer, _actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>(message);
		}

		[DebuggerNonUserCode]
		public TestWithClause<T> With(Action<T> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper<T>(_actionContainer,
			                                                                      initializationForActionParameter));
			return this;
		}

		[DebuggerNonUserCode]
		public TestWithClause<T> With(Action initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper(initializationForActionParameter));
			return this;
		}
	}

	public class TestWithClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly TContext _context;

		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters =
			new List<IParameterActionWrapper>();

		internal TestWithClause(T actionContainer, IWhenActionWrapper actionUnderTest, TContext context)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_context = context;
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> Should<TBaseContext>(Action<T, TBaseContext> assertion) where TBaseContext : class
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters,
			                                       _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> Should(Action<T, TContext> assertion)
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters,
			                                       _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> Should(Action<TContext> assertion)
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters,
			                                       _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> Should(Action<T> assertion)
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters,
			                                       _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> Should(Action assertion)
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters,
			                                       _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return
				new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters, _context)
					.ShouldThrowException<TExceptionType>();
		}

		[DebuggerNonUserCode]
		public TestWhenClause<T, TContext> ShouldThrowException<TExceptionType>(string message)
			where TExceptionType : Exception
		{
			return new TestWhenClause<T, TContext>(_actionContainer, _actionUnderTest, _initializationsForActionParameters,
			                                       _context)
				.ShouldThrowException<TExceptionType>(message);
		}

		[DebuggerNonUserCode]
		public TestWithClause<T, TContext> With<TBaseContext>(Action<T, TBaseContext> initializationForActionParameter)
			where TBaseContext : class
		{
			var baseContext = _context as TBaseContext;
			if (baseContext == null)
			{
				throw new InvalidCastException(typeof (TContext).Name + " must inherit from " + typeof (TBaseContext) +
				                               " in order to call " + initializationForActionParameter.Method.Name);
			}
			_initializationsForActionParameters.Add(new ParameterActionWrapper<T, TBaseContext>(_actionContainer, baseContext,
			                                                                                    initializationForActionParameter));
			return this;
		}

		[DebuggerNonUserCode]
		public TestWithClause<T, TContext> With(Action<T, TContext> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper<T, TContext>(_actionContainer, _context,
			                                                                                initializationForActionParameter));
			return this;
		}

		[DebuggerNonUserCode]
		public TestWithClause<T, TContext> With(Action<TContext> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper<TContext>(_context,
			                                                                             initializationForActionParameter));
			return this;
		}

		[DebuggerNonUserCode]
		public TestWithClause<T, TContext> With(Action<T> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper<T>(_actionContainer,
			                                                                      initializationForActionParameter));
			return this;
		}

		[DebuggerNonUserCode]
		public TestWithClause<T, TContext> With(Action initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper(initializationForActionParameter));
			return this;
		}
	}
}