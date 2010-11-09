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
	public class TestExpectStaticClause
	{
		private readonly Action _actionUnderTest;
		private readonly IList<IDependencyActionWrapper> _dependencyActions = new List<IDependencyActionWrapper>();
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;

		internal TestExpectStaticClause(Action actionUnderTest,
		                                IEnumerable<IParameterActionWrapper> parameterActions)
		{
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
		}

		public TestExpectStaticClause Expect(Action dependencyAction)
		{
			_dependencyActions.Add(new DependencyActionWrapper(dependencyAction));
			return this;
		}

		public TestShouldStaticClause Should(Action assertion)
		{
			return new TestShouldStaticClause(_actionUnderTest,
			                                  _parameterActions,
			                                  _dependencyActions)
				.Should(assertion);
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldStaticClause(_actionUnderTest,
			                                  _parameterActions,
			                                  _dependencyActions)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldStaticClause ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestShouldStaticClause(_actionUnderTest,
			                                  _parameterActions,
			                                  _dependencyActions)
				.ShouldThrowException<TExceptionType>(message);
		}
	}

	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class TestExpectStaticClause<TContext>
	{
		private readonly IWhenActionWrapper _actionUnderTest;
		private readonly TContext _context;
		private readonly IList<IDependencyActionWrapper> _dependencyActions = new List<IDependencyActionWrapper>();
		private readonly IEnumerable<IParameterActionWrapper> _parameterActions;

		internal TestExpectStaticClause(IWhenActionWrapper actionUnderTest,
		                                IEnumerable<IParameterActionWrapper> parameterActions,
		                                TContext context)
		{
			_actionUnderTest = actionUnderTest;
			_parameterActions = parameterActions;
			_context = context;
		}

		public TestExpectStaticClause<TContext> Expect(Action dependencyAction)
		{
			_dependencyActions.Add(new DependencyActionWrapper(dependencyAction));
			return this;
		}

		public TestShouldStaticClause<TContext> Should<TBaseContext>(Action<TBaseContext> assertion) where TBaseContext : class
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
			                                            _parameterActions,
			                                            _dependencyActions,
			                                            _context)
				.Should(assertion);
		}

		public TestShouldStaticClause<TContext> Should(Action<TContext> assertion)
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
			                                            _parameterActions,
			                                            _dependencyActions,
			                                            _context)
				.Should(assertion);
		}

		public TestShouldStaticClause<TContext> Should(Action assertion)
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
			                                            _parameterActions,
			                                            _dependencyActions,
			                                            _context)
				.Should(assertion);
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>() where TExceptionType : Exception
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
			                                            _parameterActions,
			                                            _dependencyActions,
			                                            _context)
				.ShouldThrowException<TExceptionType>();
		}

		public TestShouldStaticClause<TContext> ShouldThrowException<TExceptionType>(string message) where TExceptionType : Exception
		{
			return new TestShouldStaticClause<TContext>(_actionUnderTest,
			                                            _parameterActions,
			                                            _dependencyActions,
			                                            _context)
				.ShouldThrowException<TExceptionType>(message);
		}
	}
}