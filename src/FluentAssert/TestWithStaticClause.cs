using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FluentAssert
{
	public class TestWithStaticClause
	{
		private readonly Action _actionUnderTest;
		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters = new List<IParameterActionWrapper>();

		internal TestWithStaticClause(Action actionUnderTest)
		{
			_actionUnderTest = actionUnderTest;
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause Should(Action assertion)
		{
			return new TestWhenStaticClause(_actionUnderTest, _initializationsForActionParameters)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestWhenStaticClause(_actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>();
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestWhenStaticClause(_actionUnderTest, _initializationsForActionParameters)
				.ShouldThrowException<TExceptionType>(message);
		}

		[DebuggerNonUserCode]
		public TestWithStaticClause With(Action initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper(initializationForActionParameter));
			return this;
		}
	}

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

		[DebuggerNonUserCode]
		public TestWhenStaticClause<TContext> Should<TBaseContext>(Action<TBaseContext> assertion) where TBaseContext : class
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause<TContext> Should(Action<TContext> assertion)
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause<TContext> Should(Action assertion)
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.Should(assertion);
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause<TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.ShouldThrowException<TExceptionType>();
		}

		[DebuggerNonUserCode]
		public TestWhenStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestWhenStaticClause<TContext>(_actionUnderTest, _initializationsForActionParameters, _context)
				.ShouldThrowException<TExceptionType>(message);
		}

		[DebuggerNonUserCode]
		public TestWithStaticClause<TContext> With(Action<TContext> initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper<TContext>(_context, initializationForActionParameter));
			return this;
		}

		[DebuggerNonUserCode]
		public TestWithStaticClause<TContext> With(Action initializationForActionParameter)
		{
			_initializationsForActionParameters.Add(new ParameterActionWrapper(initializationForActionParameter));
			return this;
		}
	}
}