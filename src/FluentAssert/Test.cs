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
using System.Diagnostics;

using FluentAssert.Exceptions.Rewriting;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public static class Test
	{
		public static TestGivenClause<T> Given<T>(T actionContainer)
		{
			return new TestGivenClause<T>(new ActionContainerSource<T>
			{
				GetActionContainer = () => actionContainer
			});
		}

		public static TestGivenClauseWithoutActionContainerSource<T> Given<T>()
		{
			return new TestGivenClauseWithoutActionContainerSource<T>();
		}

		public static TestGivenStaticClause Static()
		{
			return new TestGivenStaticClause();
		}

		public static void Verify(params Action[] actions)
		{
			try
			{
				new TestVerifyClause().Verify(actions);
			}
			catch (Exception e)
			{
				Exception result = null;
				bool succeeded = true;
				try
				{
					result = new ExceptionRewriter().RewriteStacktrace(e);
				}
				catch
				{
					succeeded = false;
				}
				if (!succeeded)
				{
					throw;
				}
				throw result;
			}
		}

		public static void VerifyThrowsException<TExceptionType>(params Action[] actions)
			where TExceptionType : Exception
		{
			var exceptionConfiguration = new ExceptionConfiguration(typeof(TExceptionType));
			try
			{
				new TestVerifyClause(exceptionConfiguration).Verify(actions);
			}
			catch (Exception e)
			{
				Exception result = null;
				bool succeeded = true;
				try
				{
					result = new ExceptionRewriter().RewriteStacktrace(e);
				}
				catch
				{
					succeeded = false;
				}
				if (!succeeded)
				{
					throw;
				}
				throw result;
			}
		}

		public static void VerifyThrowsException<TExceptionType>(string expectedExceptionMessage, params Action[] actions)
			where TExceptionType : Exception
		{
			var exceptionConfiguration = new ExceptionConfiguration(typeof(TExceptionType), expectedExceptionMessage);
			try
			{
				new TestVerifyClause(exceptionConfiguration).Verify(actions);
			}
			catch (Exception e)
			{
				Exception result = null;
				bool succeeded = true;
				try
				{
					result = new ExceptionRewriter().RewriteStacktrace(e);
				}
				catch
				{
					succeeded = false;
				}
				if (!succeeded)
				{
					throw;
				}
				throw result;
			}
		}
	}
}