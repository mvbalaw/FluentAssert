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
	public class TestExpectClause<T>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly IList<IDependencyActionWrapper> _dependencyActions = new List<IDependencyActionWrapper>();
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;

		internal TestExpectClause(T actionContainer,
			IWhenActionWrapper actionUnderTest,
			IEnumerable<IParameterActionWrapper> parameterActions)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
		}

		public TestExpectClause<T> Expect(Action dependencyAction)
		{
			_dependencyActions.Add(new DependencyActionWrapper(dependencyAction));
			return this;
		}

		public TestShouldClause<T> Should(Action assertion)
		{
			return new TestShouldClause<T>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions)
				.Should(assertion);
		}

		public TestShouldClause<T> Should(Action<T> assertion)
		{
			return new TestShouldClause<T>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions)
				.Should(assertion);
		}

		public TestShouldClause<T> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldClause<T>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldClause<T> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestShouldClause<T>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions)
				.ShouldThrowException<TExceptionType>(message);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestExpectClause<T, TContext>
	{
		private readonly T _actionContainer;
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly TContext _context;
		private readonly IList<IDependencyActionWrapper> _dependencyActions = new List<IDependencyActionWrapper>();
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;

		internal TestExpectClause(T actionContainer,
			IWhenActionWrapper actionUnderTest,
			IEnumerable<IParameterActionWrapper> parameterActions,
			TContext context)
		{
			_actionContainer = actionContainer;
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
			_context = context;
		}

		public TestExpectClause<T, TContext> Expect(Action dependencyAction)
		{
			_dependencyActions.Add(new DependencyActionWrapper(dependencyAction));
			return this;
		}

		public TestShouldClause<T, TContext> Should<TBaseContext>(Action<T, TBaseContext> assertion) where TBaseContext : class
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action<T, TContext> assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action<TContext> assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action<T> assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> Should(Action assertion)
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.Should(assertion);
		}

		public TestShouldClause<T, TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldClause<T, TContext> ShouldThrowException<TExceptionType>(string message)
			where TExceptionType : Exception
		{
			return new TestShouldClause<T, TContext>(_actionContainer,
				_actionUnderTest,
				_parameterActions,
				_dependencyActions,
				_context)
				.ShouldThrowException<TExceptionType>(message);
		}
	}
}