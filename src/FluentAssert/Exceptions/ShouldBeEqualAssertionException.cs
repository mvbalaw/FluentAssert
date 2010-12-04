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
	public class ShouldBeEqualAssertionException : AssertionException
	{
		protected ShouldBeEqualAssertionException(SerializationInfo info, StreamingContext context)
			:base(info, context)
		{
		}

		public ShouldBeEqualAssertionException(string message)
			: base(message)
		{
		}

		public static string CreateMessage(object input, object expected)
		{
			string displayInput = ExpectedMessageBuilder.ToDisplayableString(input);
			string displayExpected = ExpectedMessageBuilder.ToDisplayableString(expected);
			string prefix = "";
			bool showStringDifferences = expected != null && input != null && input.GetType() == typeof(string);
			int differenceIndex = 0;
			if (showStringDifferences)
			{
				string stringInput = input as string;
				string stringExpected = expected as string;
				differenceIndex = GetDifferenceIndex(stringInput, stringExpected);
				displayInput = ExpectedMessageBuilder.ToDisplayableString(stringInput, differenceIndex);
				displayExpected = ExpectedMessageBuilder.ToDisplayableString(stringExpected, differenceIndex);
				int inputLength = stringInput.Length;
				int expectedLength = stringExpected.Length;
				if (inputLength == expectedLength)
				{
					prefix = "  String lengths are both " + expectedLength + ".";
				}
				else
				{
					prefix = "  Expected string length " + expectedLength + " but was " + inputLength + ".";
				}
				prefix += " Strings differ at index " + differenceIndex + "." + Environment.NewLine;
			}

			string message = ExpectedMessageBuilder.BuildFor(displayExpected, displayInput);
			string suffix = "";
			if (showStringDifferences)
			{
				if (differenceIndex > displayExpected.Length)
				{
					differenceIndex = ExpectedMessageBuilder.Ellipsis.Length + ExpectedMessageBuilder.StringLeftStart;
				}
				suffix += "  " + "^".PadLeft(12 + differenceIndex, '-') + Environment.NewLine;
			}
			return prefix + message + suffix;
		}

		private static int GetDifferenceIndex(string input, string expected)
		{
			if (String.IsNullOrEmpty(input) || String.IsNullOrEmpty(expected))
			{
				return 0;
			}
			int last = Math.Min(input.Length, expected.Length);
			for (int i = 0; i < last; i++)
			{
				if (input[i] != expected[i])
				{
					return i;
				}
			}
			return last;
		}
	}
}