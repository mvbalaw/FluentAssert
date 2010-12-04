//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************
using System.Collections.Generic;
using System.Diagnostics;

namespace FluentAssert.Exceptions.Rewriting
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public static class Int32Extensions
	{
		public static byte[] To7bitVariableLengthByteArray(this int input)
		{
			var bytes = new List<byte>();
			do
			{
				byte value = (byte)(input & 0x7f);
				input = input >> 7;
				if (input > 0)
				{
					value |= 0x80;
				}
				bytes.Add(value);
			} while (input > 0);
			return bytes.ToArray();
		}
	}
}