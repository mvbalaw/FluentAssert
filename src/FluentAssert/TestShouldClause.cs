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
	public class TestShouldClause<T>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly IList<IAssertionActionWrapper> _assertions = new List<IAssertionActionWrapper>();
		private readonly IEnumerable<IDependencyActionWrapper> _dependencyActions;
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;
		private Action<T> _performAction;

		internal TestShouldClause(T actionContainer,
			IWhenActionWrapper actionUnderTest,
			IEnumerable<IParameterActionWrapper> parameterActions)
			: this(actionContainer, actionUnderTest, parameterActions, new List<IDependencyActionWrapper>())
		{
		}

		internal TestShouldClause(T actionContainer,
			IWhenActionWrapper actionUnderTest,
			IEnumerable<IParameterActionWrapper> parameterActions,
			IEnumerable<IDependencyActionWrapper> dependencyActions)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
			_dependencyActions = dependencyActions;
			_performAction = (T item) => _actionUnderTest.Act();
		}

		public TestShouldClause<T> Should(Action assertion)
		{
			_assertions.Add(new AssertionActionWrapper(assertion));
			return this;
		}

		public TestShouldClause<T> Should(Action<T> assertion)
		{
			_assertions.Add(new AssertionActionWrapper<T>(_actionContainer, assertion));
			return this;
		}

		public TestShouldClause<T> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = (T item) => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest.Act());
			return this;
		}

		public TestShouldClause<T> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			_performAction = (T item) => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest.Act(), message);
			return this;
		}

		public void Verify()
		{
			try
			{
				TestRunner.Verify(_actionUnderTest.Description,
					_parameterActions,
					() => _performAction(_actionContainer),
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
	public class TestShouldClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly IList<IAssertionActionWrapper> _assertions = new List<IAssertionActionWrapper>();
		private readonly TContext _context;
		private readonly IEnumerable<IDependencyActionWrapper> _dependencyActions;
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;
		private Action<T, TContext> _performAction;

		internal TestShouldClause(T actionContainer,
			IWhenActionWrapper actionUnderTest,
			IEnumerable<IParameterActionWrapper> parameterActions,
			TContext context)
			: this(actionContainer, actionUnderTest, parameterActions, new List<IDependencyActionWrapper>(), context)
		{
		}

		internal TestShouldClause(T actionContainer,
			IWhenActionWrapper actionUnderTest,
			IEnumerable<IParameterActionWrapper> parameterActions,
			IEnumerable<IDependencyActionWrapper> dependencyActions,
			TContext context)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
			_dependencyActions = dependencyActions;
			_context = context;
			_performAction = (T item, TContext testContext) => _actionUnderTest.Act();
		}

		public TestShouldClause<T, TContext> Should<TBaseContext>(Action<T, TBaseContext> assertion) where TBaseContext : class
		{
			var baseContext = _context as TBaseContext;
			if (baseContext == null)
			{
				throw new InvalidCastException(typeof(TContext).Name + " must inherit from " + typeof(TBaseContext) +
					" in order to call " + assertion.Method.Name);
			}

			_assertions.Add(new AssertionActionWrapper<T, TBaseContext>(_actionContainer, baseContext, assertion));
			return this;
		}

		public TestShouldClause<T, TContext> Should(Action<T, TContext> assertion)
		{
			_assertions.Add(new AssertionActionWrapper<T, TContext>(_actionContainer, _context, assertion));
			return this;
		}

		public TestShouldClause<T, TContext> Should(Action<TContext> assertion)
		{
			_assertions.Add(new AssertionActionWrapper<TContext>(_context, assertion));
			return this;
		}

		public TestShouldClause<T, TContext> Should(Action<T> assertion)
		{
			_assertions.Add(new AssertionActionWrapper<T>(_actionContainer, assertion));
			return this;
		}

		public TestShouldClause<T, TContext> Should(Action assertion)
		{
			_assertions.Add(new AssertionActionWrapper(assertion));
			return this;
		}

		public TestShouldClause<T, TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			_performAction = (T item, TContext testContext) => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest.Act());
			return this;
		}

		public TestShouldClause<T, TContext> ShouldThrowException<TExceptionType>(string message)
			where TExceptionType : Exception
		{
			_performAction =
				(T item, TContext testContext) => AssertExtensions.ShouldThrow<TExceptionType>(() => _actionUnderTest.Act(), message);
			return this;
		}

		public void Verify()
		{
			try
			{
				TestRunner.Verify(_actionUnderTest.Description,
					_parameterActions,
					() => _performAction(_actionContainer, _context),
					_dependencyActions,
					_assertions
					);
			}
			catch (Exception e)
			{
				throw new AssertionException(e);
			}
		}
	}
}