using System;
using System.Collections.Generic;
using System.Diagnostics;

using NUnit.Framework;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWhenStaticClause
	{
		private readonly Action _actionUnderTest;
		private readonly IList<IAssertionActionWrapper> _assertions = new List<IAssertionActionWrapper>();
		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters;
		private Action _performAction;

		internal TestWhenStaticClause(Action actionUnderTest, IList<IParameterActionWrapper> initializationsForActionParameters)
		{
			_actionUnderTest = actionUnderTest;
			_initializationsForActionParameters = initializationsForActionParameters;
			_performAction = () => _actionUnderTest();
		}

		public TestWhenStaticClause Should(Action assertion)
		{
			_assertions.Add(new AssertionActionWrapper(assertion));
			return this;
		}

		public TestWhenStaticClause ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = () => Assert.Throws<TExceptionType>(() => _actionUnderTest());
			return this;
		}

		public TestWhenStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = () => Assert.Throws<TExceptionType>(() => _actionUnderTest(), message);
			return this;
		}

		public void Verify()
		{
			TestRunner.Verify(ActionDescriptionBuilder.BuildFor(_actionUnderTest),
			                  _initializationsForActionParameters,
			                  () => _performAction(),
			                  _assertions);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWhenStaticClause<TContext>
	{
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly IList<IAssertionActionWrapper> _assertions = new List<IAssertionActionWrapper>();
		private readonly TContext _context;
		private readonly IList<IParameterActionWrapper> _initializationsForActionParameters;
		private Action<TContext> _performAction;

		internal TestWhenStaticClause(IWhenActionWrapper actionUnderTest, IList<IParameterActionWrapper> initializationsForActionParameters, TContext context)
		{
			_actionUnderTest = actionUnderTest;
			_initializationsForActionParameters = initializationsForActionParameters;
			_context = context;
			_performAction = (TContext testContext) => _actionUnderTest.Act();
		}

		public TestWhenStaticClause<TContext> Should<TBaseContext>(Action<TBaseContext> assertion) where TBaseContext : class
		{
			var baseContext = _context as TBaseContext;
			if (baseContext == null)
			{
				throw new InvalidCastException(typeof(TContext).Name + " must inherit from " + typeof(TBaseContext) + " in order to call " + assertion.Method.Name);
			}

			_assertions.Add(new AssertionActionWrapper<TBaseContext>(baseContext, assertion));
			return this;
		}

		public TestWhenStaticClause<TContext> Should(Action<TContext> assertion)
		{
			_assertions.Add(new AssertionActionWrapper<TContext>(_context, assertion));
			return this;
		}

		public TestWhenStaticClause<TContext> Should(Action assertion)
		{
			_assertions.Add(new AssertionActionWrapper(assertion));
			return this;
		}

		public TestWhenStaticClause<TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = (TContext context) => Assert.Throws<TExceptionType>(() => _actionUnderTest.Act());
			return this;
		}

		public TestWhenStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = (TContext context) => Assert.Throws<TExceptionType>(() => _actionUnderTest.Act(), message);
			return this;
		}

		public void Verify()
		{
			TestRunner.Verify(_actionUnderTest.Description,
			                  _initializationsForActionParameters,
			                  () => _performAction(_context),
			                  _assertions);
		}
	}
}