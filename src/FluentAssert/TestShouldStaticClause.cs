using System;
using System.Collections.Generic;
using System.Diagnostics;

using NUnit.Framework;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestShouldStaticClause
	{
		private readonly Action _actionUnderTest;
		private readonly IList<IAssertionActionWrapper> _assertions = new List<IAssertionActionWrapper>();
		private readonly IEnumerable<IDependencyActionWrapper> _dependencyActions;
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;
		private Action _performAction;

		internal TestShouldStaticClause(Action actionUnderTest,
		                                IEnumerable<IParameterActionWrapper> parameterActions)
			: this(actionUnderTest, parameterActions, new List<IDependencyActionWrapper>())
		{
		}

		internal TestShouldStaticClause(Action actionUnderTest,
		                                IEnumerable<IParameterActionWrapper> parameterActions,
		                                IEnumerable<IDependencyActionWrapper> dependencyActions)
		{
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
			_performAction = () => _actionUnderTest();
			_dependencyActions = dependencyActions;
		}

		public TestShouldStaticClause Should(Action assertion)
		{
			_assertions.Add(new AssertionActionWrapper(assertion));
			return this;
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = () => Assert.Throws<TExceptionType>(() => _actionUnderTest());
			return this;
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = () => Assert.Throws<TExceptionType>(() => _actionUnderTest(), message);
			return this;
		}

		public void Verify()
		{
			TestRunner.Verify(ActionDescriptionBuilder.BuildFor(_actionUnderTest),
			                  _parameterActions,
			                  () => _performAction(),
			                  _dependencyActions,
			                  _assertions);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestShouldStaticClause<TContext>
	{
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly IList<IAssertionActionWrapper> _assertions = new List<IAssertionActionWrapper>();
		private readonly TContext _context;
		private readonly IEnumerable<IDependencyActionWrapper> _dependencyActions;
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;
		private Action<TContext> _performAction;

		internal TestShouldStaticClause(IWhenActionWrapper actionUnderTest,
		                                IEnumerable<IParameterActionWrapper> parameterActions,
		                                TContext context)
			: this(actionUnderTest, parameterActions, new List<IDependencyActionWrapper>(), context)
		{
		}

		internal TestShouldStaticClause(IWhenActionWrapper actionUnderTest,
		                                IEnumerable<IParameterActionWrapper> parameterActions,
		                                IEnumerable<IDependencyActionWrapper> dependencyActions,
		                                TContext context)
		{
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
			_context = context;
			_performAction = (TContext testContext) => _actionUnderTest.Act();
			_dependencyActions = dependencyActions;
		}

		public TestShouldStaticClause<TContext> Should<TBaseContext>(Action<TBaseContext> assertion) where TBaseContext : class
		{
			var baseContext = _context as TBaseContext;
			if (baseContext == null)
			{
				throw new InvalidCastException(typeof(TContext).Name + " must inherit from " + typeof(TBaseContext) + " in order to call " + assertion.Method.Name);
			}

			_assertions.Add(new AssertionActionWrapper<TBaseContext>(baseContext, assertion));
			return this;
		}

		public TestShouldStaticClause<TContext> Should(Action<TContext> assertion)
		{
			_assertions.Add(new AssertionActionWrapper<TContext>(_context, assertion));
			return this;
		}

		public TestShouldStaticClause<TContext> Should(Action assertion)
		{
			_assertions.Add(new AssertionActionWrapper(assertion));
			return this;
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = (TContext context) => Assert.Throws<TExceptionType>(() => _actionUnderTest.Act());
			return this;
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = (TContext context) => Assert.Throws<TExceptionType>(() => _actionUnderTest.Act(), message);
			return this;
		}

		public void Verify()
		{
			TestRunner.Verify(_actionUnderTest.Description,
			                  _parameterActions,
			                  () => _performAction(_context),
			                  _dependencyActions,
			                  _assertions);
		}
	}
}