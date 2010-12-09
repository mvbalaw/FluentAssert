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
using System.Reflection;

namespace FluentAssert
{
	internal static class ExceptionExtensions
	{
		public static void PreserveStackTrace(this Exception exception)
		{
			var preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace",
			                                                     BindingFlags.Instance | BindingFlags.NonPublic);
			preserveStackTrace.Invoke(exception, null);
		}
	}
}