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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FluentAssert.Exceptions.Rewriting
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class BinarySerializationPartialExceptionClassSegment : IBinarySerializationSegment
	{
		public bool IsMatch(MemoryStream memoryStream)
		{
			byte typeId = memoryStream.PeekByte();
			return typeId == BinarySerializationSegment.RuntimeClassSegment.TypeId ||
			       typeId == BinarySerializationSegment.ExternalClassSegment.TypeId;
		}

		public void Skip(MemoryStream memoryStream)
		{
			SkipPrefix(memoryStream);
			memoryStream.ReadStringHaving7bitVariableLengthInt32Prefix();
			short propertyCount = memoryStream.ReadLEShort();
			memoryStream.ReadLEShort();
			for (int i = 0; i < propertyCount; i++)
			{
				memoryStream.ReadStringHaving7bitVariableLengthInt32Prefix();
			}
			var propertyTypes = new List<byte>();
			for (int i = 0; i < propertyCount; i++)
			{
				propertyTypes.Add((byte)memoryStream.ReadByte());
			}
			int referencePropertyCount = propertyTypes.Count(x => x == (int)BinarySerializationPropertyType.Reference);
			for (int i = 0; i < referencePropertyCount; i++)
			{
				memoryStream.ReadStringHaving7bitVariableLengthInt32Prefix();
			}
			for (int i = 0; i < referencePropertyCount; i++)
			{
				byte typeId = memoryStream.PeekByte();
				var handler = BinarySerializationSegment.GetFor(typeId);
				handler.Skip(memoryStream);
			}
			byte nextTypeId = memoryStream.PeekByte();
			if (nextTypeId == BinarySerializationSegment.EndVariableLengthObjectSegment.TypeId)
			{
				BinarySerializationSegment.EndVariableLengthObjectSegment.Handler.Skip(memoryStream);
			}
			nextTypeId = memoryStream.PeekByte();
			if (nextTypeId != BinarySerializationSegment.VariableLengthObjectSegment.TypeId)
			{
				throw new ArgumentException("Expected next segment to be " + BinarySerializationSegment.VariableLengthObjectSegment.TypeId
				                            + " but was " + nextTypeId);
			}
			// the next segment should contain the text of the StackTrace
		}

		public void SkipPrefix(MemoryStream memoryStream)
		{
			memoryStream.ReadByte();
			memoryStream.ReadLEShort();
			memoryStream.ReadLEShort();
		}
	}
}