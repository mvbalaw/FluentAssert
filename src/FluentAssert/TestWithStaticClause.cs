using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWithStaticClause
	{
		private readonly Action _actionUnderTest;
		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters = new List<IParameterActionWrapper>();

		internal TestWithStaticClause(Action actionUnderTest)
		{
			_actionUnderTest = actionUnderTest;
		}

		public TestWhenStaticClause Should(Action assertion)
		{
			return new TestWhenStaticClause(_actionUnderTest, _initializationsForActionParameters)
				.Should(assertion);
		}

		public TestWhenStaticClause ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestWhenStaticClause(_actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>();
		}

		public TestWhenStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestWhenStaticClause(_actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWithStaticClause With(Action initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper(initializationForActionParameter));
			return this;
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWithStaticClause<TContext>
	{
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly TContext _context;
		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters = new List<IParameterActionWrapper>();

		internal TestWithStaticClause(IWhenActionWrapper actionUnderTest, TContext context)
		{
			_actionUnderTest = actionUnderTest;
			_context = context;
		}

		public TestWhenStaticClause<TContext> Should<TBaseContext>(Action<TBaseContext> assertion) where TBaseContext : class
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		public TestWhenStaticClause<TContext> Should(Action<TContext> assertion)
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		public TestWhenStaticClause<TContext> Should(Action assertion)
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		public TestWhenStaticClause<TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.ShouldThrowException<TExceptionType>();
		}

		public TestWhenStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWithStaticClause<TContext> With(Action<TContext> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper<TContext>(_context, initializationForActionParameter));
			return this;
		}

		public TestWithStaticClause<TContext> With(Action initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper(initializationForActionParameter));
			return this;
		}
	}
}