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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace FluentAssert.Exceptions.Rewriting
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public static class MemoryStreamExtensions
	{
		public static byte PeekByte(this MemoryStream memoryStream)
		{
			byte type = (byte)memoryStream.ReadByte();
			memoryStream.Position--;
			return type;
		}

		public static int Read7bitVariableLengthInt32(this MemoryStream memoryStream)
		{
			int result = 0;
			int byteCount = 0;
			bool readMore;
			do
			{
				int rawValue = memoryStream.ReadByte();
				int value = (rawValue & 0x7f);
				readMore = (rawValue >> 7) > 0;
				result = result | (value << (7 * byteCount));
				byteCount++;
			} while (readMore && byteCount < 4);
			return result;
		}

		public static int ReadLEInt32(this MemoryStream memoryStream)
		{
			var bytes = new byte[4];
			memoryStream.Read(bytes, 0, 4);
			int result = BitConverter.ToInt32(bytes, 0);
			if (!BitConverter.IsLittleEndian)
			{
				result = IPAddress.NetworkToHostOrder(result);
			}
			return result;
		}

		public static short ReadLEShort(this MemoryStream memoryStream)
		{
			var bytes = new byte[2];
			memoryStream.Read(bytes, 0, 2);
			short result = BitConverter.ToInt16(bytes, 0);
			if (!BitConverter.IsLittleEndian)
			{
				result = IPAddress.NetworkToHostOrder(result);
			}
			return result;
		}

		public static string ReadString(this MemoryStream memoryStream, int length)
		{
			var bytes = new byte[length];
			memoryStream.Read(bytes, 0, length);
			string result = Encoding.ASCII.GetString(bytes);
			return result;
		}

		public static string ReadStringHaving7bitVariableLengthInt32Prefix(this MemoryStream memoryStream)
		{
			int length = memoryStream.Read7bitVariableLengthInt32();
			string result = memoryStream.ReadString(length);
			return result;
		}
	}
}