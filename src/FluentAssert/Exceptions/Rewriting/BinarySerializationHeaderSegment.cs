//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************
using System.Diagnostics;
using System.IO;

namespace FluentAssert.Exceptions.Rewriting
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class BinarySerializationHeaderSegment : IBinarySerializationSegment
	{
		public bool IsMatch(MemoryStream memoryStream)
		{
			return memoryStream.Position == 0;
		}

		public void Skip(MemoryStream memoryStream)
		{
			memoryStream.ReadByte();
			memoryStream.ReadLEInt32();
			memoryStream.ReadLEInt32();
			memoryStream.ReadLEInt32();
			memoryStream.ReadLEInt32();
		}
	}
}