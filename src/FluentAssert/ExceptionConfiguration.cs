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

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class ExceptionConfiguration
	{
		public ExceptionConfiguration()
		{
		}

		public ExceptionConfiguration(Type expectedExceptionType)
		{
			ExpectedExceptionType = expectedExceptionType;
			ExpectException = true;
		}

		public ExceptionConfiguration(Type expectedExceptionType, string expectedExceptionMessage)
		{
			ExpectedExceptionType = expectedExceptionType;
			ExpectException = true;
			ExpectedExceptionMessage = expectedExceptionMessage;
			ExpectExceptionMessage = true;
		}

		public bool ExpectException { get; private set; }
		public bool ExpectExceptionMessage { get; private set; }
		public string ExpectedExceptionMessage { get; private set; }
		public Type ExpectedExceptionType { get; private set; }

		public void CaughtExpectedException()
		{
			ExpectException = false;
		}
	}
}