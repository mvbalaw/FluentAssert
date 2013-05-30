//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;

using FluentAssert.Exceptions;

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
			_performAction = () => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest());
			return this;
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = () => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest(), message);
			return this;
		}

		public void Verify()
		{
			try
			{
				TestRunner.Verify(ActionDescriptionBuilder.BuildFor(_actionUnderTest),
								  _parameterActions,
								  () => _performAction(),
								  _dependencyActions,
								  _assertions);
			}
			catch (Exception e)
			{
				throw new AssertionException(e);
			}
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
			_performAction = (TContext context) => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest.Act());
			return this;
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = (TContext context) => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest.Act(), message);
			return this;
		}

		public void Verify()
		{
			try
			{
				TestRunner.Verify(_actionUnderTest.Description,
								  _parameterActions,
								  () => _performAction(_context),
								  _dependencyActions,
								  _assertions);
			}
			catch (Exception e)
			{
				throw new AssertionException(e);
			}
		}
	}
}