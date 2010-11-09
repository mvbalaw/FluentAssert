//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************
namespace FluentAssert.Exceptions
{
	public class ShouldBeNullAssertionException : AssertionException
	{
		public ShouldBeNullAssertionException(string errorMessage)
			: base(errorMessage)
		{
		}

		public static string CreateMessage(string actual)
		{
			string message = ExpectedMessageBuilder.BuildFor("null", actual);
			return message;
		}
	}
}