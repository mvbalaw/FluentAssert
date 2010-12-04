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
	public class BinarySerializationVariableLengthObjectSegment : IBinarySerializationSegment
	{
		public bool IsMatch(MemoryStream memoryStream)
		{
			byte typeId = memoryStream.PeekByte();
			return typeId == BinarySerializationSegment.VariableLengthObjectSegment.TypeId;
		}

		public void Skip(MemoryStream memoryStream)
		{
			memoryStream.ReadByte();
			memoryStream.ReadLEShort();
			memoryStream.ReadLEShort();
			memoryStream.ReadStringHaving7bitVariableLengthInt32Prefix();
			byte typeId;
			do
			{
				typeId = memoryStream.PeekByte();
				var handler = BinarySerializationSegment.GetFor(typeId);
				handler.Skip(memoryStream);
			} while (typeId != BinarySerializationSegment.EndVariableLengthObjectSegment.TypeId);
		}
	}
}