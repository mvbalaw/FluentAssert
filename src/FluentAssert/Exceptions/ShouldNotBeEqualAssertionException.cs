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
using System.Runtime.Serialization;

namespace FluentAssert.Exceptions
{
	[Serializable]
	public class ShouldNotBeEqualAssertionException : AssertionException
	{
		protected ShouldNotBeEqualAssertionException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		public ShouldNotBeEqualAssertionException(string input, string expected)
			: base(CreateMessage(input, expected))
		{
		}

		public ShouldNotBeEqualAssertionException(string message)
			: base(message)
		{
		}

		public static string CreateMessage(object input, object expected)
		{
			string displayInput = ExpectedMessageBuilder.ToDisplayableString(input);
			string displayExpected = ExpectedMessageBuilder.ToDisplayableString(expected);

			string message = "  Expected: not " + displayExpected + Environment.NewLine
			                 + "  But was:  " + displayInput + Environment.NewLine;

			return message;
		}
	}
}