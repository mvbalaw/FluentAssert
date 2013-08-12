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
	public class TestWhenStaticClause
	{
		private readonly Action _actionUnderTest;
		private readonly IList<IParameterActionWrapper> _parameterActions = new List<IParameterActionWrapper>();

		internal TestWhenStaticClause(Action actionUnderTest)
		{
			_actionUnderTest = actionUnderTest;
		}

		public TestExpectStaticClause Expect(Action dependencyAction)
		{
			return new TestExpectStaticClause(_actionUnderTest, _parameterActions)
				.Expect(dependencyAction);
		}

		public TestShouldStaticClause Should(Action assertion)
		{
			return new TestShouldStaticClause(_actionUnderTest,
				_parameterActions)
				.Should(assertion);
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldStaticClause(_actionUnderTest,
				_parameterActions)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestShouldStaticClause(_actionUnderTest,
				_parameterActions)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWhenStaticClause With(Action parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper(parameterAction));
			return this;
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestWhenStaticClause<TContext>
	{
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly TContext _context;
		private readonly IList<IParameterActionWrapper> _parameterActions = new List<IParameterActionWrapper>();

		internal TestWhenStaticClause(IWhenActionWrapper actionUnderTest, TContext context)
		{
			_actionUnderTest = actionUnderTest;
			_context = context;
		}

		public TestExpectStaticClause<TContext> Expect(Action dependencyAction)
		{
			return new TestExpectStaticClause<TContext>(_actionUnderTest, _parameterActions, _context)
				.Expect(dependencyAction);
		}

		public TestShouldStaticClause<TContext> Should<TBaseContext>(Action<TBaseContext> assertion) where TBaseContext : class
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
				_parameterActions,
				_context)
				.Should(assertion);
		}

		public TestShouldStaticClause<TContext> Should(Action<TContext> assertion)
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
				_parameterActions,
				_context)
				.Should(assertion);
		}

		public TestShouldStaticClause<TContext> Should(Action assertion)
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
				_parameterActions,
				_context)
				.Should(assertion);
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
				_parameterActions,
				_context)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
				_parameterActions,
				_context)
				.ShouldThrowException<TExceptionType>(message);
		}

		public TestWhenStaticClause<TContext> With(Action<TContext> parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper<TContext>(_context, parameterAction));
			return this;
		}

		public TestWhenStaticClause<TContext> With(Action parameterAction)
		{
			_parameterActions.Add(new ParameterActionWrapper(parameterAction));
			return this;
		}
	}
}