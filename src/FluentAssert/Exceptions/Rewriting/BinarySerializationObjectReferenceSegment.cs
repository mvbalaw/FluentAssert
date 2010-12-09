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
	public class BinarySerializationObjectReferenceSegment : IBinarySerializationSegment
	{
		public bool IsMatch(MemoryStream memoryStream)
		{
			byte typeId = memoryStream.PeekByte();
			return typeId == BinarySerializationSegment.ObjectReferenceSegment.TypeId;
		}

		public void Skip(MemoryStream memoryStream)
		{
			memoryStream.ReadByte();
			memoryStream.ReadLEShort();
			memoryStream.ReadLEShort();
		}
	}
}