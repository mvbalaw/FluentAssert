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

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWhenClause<T>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;

		private readonly IList<IParameterActionWrapper> _parameterActions = new List<IParameterActionWrapper>();

		internal TestWhenClause(T actionContainer, IWhenActionWrapper actionUnderTest)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
		}

		public TestExpectClause<T> Expect(Action dependencyAction)
		{
			return new TestExpectClause<T>(_actionContainer,
			                               _actionUnderTest,
			                               _parameterActions)
				.Expect(dependencyAction);
		}

		public TestShouldClause<T> Should(Action<T> assertion)
		{
			return new TestShouldClause<T>(_actionContainer,
			                               _actionUnderTest,
			                               _parameterActions)
				.Should(assertion);
		}

		public TestShouldClause<T> Should(Action assertion)
		{
			return new TestShouldClause<T>(_actionContainer,
			                               _actionUnderTest,
			                               _parameterActions)
				.Should(assertion);
		}

		public TestShouldClause<T> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldClause<T>(_actionContainer,
			                               _actionUnderTest,
			                               _parameterActions)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldClause<T> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestShouldClause<T>(_actionContainer,
			                               _actionUnderTest,
			                               _parameterActions)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWhenClause<T> With(Action<T> parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper<T>(_actionContainer,
			                                                    parameterAction));
			return this;
		}

		public TestWhenClause<T> With(Action parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper(parameterAction));
			return this;
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWhenClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly TContext _context;

		private readonly IList<IParameterActionWrapper> _parameterActions = new List<IParameterActionWrapper>();

		internal TestWhenClause(T actionContainer, IWhenActionWrapper actionUnderTest, TContext context)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_context = context;
		}

		public TestExpectClause<T, TContext> Expect(Action dependencyAction)
		{
			return new TestExpectClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.Expect(dependencyAction);
		}

		public TestShouldClause<T, TContext> Should<TBaseContext>(Action<T, TBaseContext> assertion) where TBaseContext : class
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action<T, TContext> assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action<TContext> assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action<T> assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return
				new TestShouldClause<T, TContext>(_actionContainer,
				                                  _actionUnderTest,
				                                  _parameterActions,
				                                  _context)
					.ShouldThrowException<TExceptionType>();
		}

		public TestShouldClause<T, TContext> ShouldThrowException<TExceptionType>(string message)
			where TExceptionType : Exception
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
			                                         _actionUnderTest,
			                                         _parameterActions,
			                                         _context)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWhenClause<T, TContext> With<TBaseContext>(Action<T, TBaseContext> parameterAction)
			where TBaseContext : class
		{
			var baseContext = _context as TBaseContext;
			if (baseContext == null)
			{
				throw new InvalidCastException(typeof(TContext).Name + " must inherit from " + typeof(TBaseContext) +
				                               " in order to call " + parameterAction.Method.Name);
			}
			_parameterActions.Add(new ParameterActionWrapper<T, TBaseContext>(_actionContainer, baseContext,
			                                                                  parameterAction));
			return this;
		}

		public TestWhenClause<T, TContext> With(Action<T, TContext> parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper<T, TContext>(_actionContainer, _context,
			                                                              parameterAction));
			return this;
		}

		public TestWhenClause<T, TContext> With(Action<TContext> parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper<TContext>(_context,
			                                                           parameterAction));
			return this;
		}

		public TestWhenClause<T, TContext> With(Action<T> parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper<T>(_actionContainer,
			                                                    parameterAction));
			return this;
		}

		public TestWhenClause<T, TContext> With(Action parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper(parameterAction));
			return this;
		}
	}
}