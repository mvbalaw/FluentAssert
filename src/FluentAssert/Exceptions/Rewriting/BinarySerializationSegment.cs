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

namespace FluentAssert.Exceptions.Rewriting
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class BinarySerializationSegment
	{
		private static readonly Dictionary<byte, IBinarySerializationSegment> Values = new Dictionary<byte, IBinarySerializationSegment>();

		public static BinarySerializationSegment AssemblyInfoSegment = new BinarySerializationSegment(0x0c, new BinarySerializationAssemblyInfoSegment());
		public static BinarySerializationSegment BoxedPrimitiveSegment = new BinarySerializationSegment(0x08, new BinarySerializationBoxedPrimitiveSegment());
		public static BinarySerializationSegment EndVariableLengthObjectSegment = new BinarySerializationSegment(0x0a, new BinarySerializationEndVariableLengthObjectSegment());
		public static BinarySerializationSegment ExternalClassSegment = new BinarySerializationSegment(0x05, new BinarySerializationPartialExceptionClassSegment());
		public static BinarySerializationSegment ExternalVariableLengthObjectSegment = new BinarySerializationSegment(0x02, new BinarySerializationExternalVariableLengthObjectSegment());
		public static BinarySerializationSegment RuntimeClassSegment = new BinarySerializationSegment(0x04, new BinarySerializationPartialExceptionClassSegment());
		public static BinarySerializationSegment VariableLengthObjectSegment = new BinarySerializationSegment(0x06, new BinarySerializationVariableLengthObjectSegment());

		public BinarySerializationSegment(byte typeId, IBinarySerializationSegment handler)
		{
			TypeId = typeId;
			Handler = handler;
			Values.Add(typeId, handler);
		}

		public IBinarySerializationSegment Handler { get; private set; }
		public byte TypeId { get; private set; }

		public static IBinarySerializationSegment GetFor(byte typeId)
		{
			IBinarySerializationSegment handler;
			if (!Values.TryGetValue(typeId, out handler))
			{
				throw new ArgumentException(String.Format("don't know how to handle segment type '0x{0:x2}'", typeId));
			}
			return handler;
		}
	}
}