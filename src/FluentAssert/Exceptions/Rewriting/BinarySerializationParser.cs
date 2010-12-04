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
using System.Text;

namespace FluentAssert.Exceptions.Rewriting
{
    public class BinarySerializationParser
	{
		private const int ReadMoreMask = 1 << 7;
		private readonly Dictionary<byte, Action> _sectionTypeActionMap;
		private byte[] _bytes;
		private bool _found;
		private int _offset;
		private bool _reachedEndOfFile;

		public BinarySerializationParser()
		{
			_sectionTypeActionMap = new Dictionary<byte, Action>();
			_sectionTypeActionMap.Add(0x00, SkipInt32);
			_sectionTypeActionMap.Add(0x01, SkipString);
			_sectionTypeActionMap.Add(0x02, SkipUnnamedObjectHierarchy);
			_sectionTypeActionMap.Add(0x03, SkipNamedObjectHierarchy);
			_sectionTypeActionMap.Add(0x04, SkipClass);
			_sectionTypeActionMap.Add(0x05, SkipClass);
			_sectionTypeActionMap.Add(0x06, SkipNamedObjectHierarchy);
			_sectionTypeActionMap.Add(0x08, SkipNullObject);
			_sectionTypeActionMap.Add(0x0a, SkipEndOfObject);
			_sectionTypeActionMap.Add(0x0b, SkipEndOfObject);
			_sectionTypeActionMap.Add(0x0c, SkipAssemblyInfo);
		}

		public int LocateStackTrace(byte[] input)
		{
			_bytes = input;
			_found = false;

			_offset = 0;
			SkipHeader();
			while (_offset < input.Length && !_found)
			{
				byte sectionType = _bytes[_offset];
				_sectionTypeActionMap[sectionType]();
			}

			return _found ? _offset : -1;
		}

		private int ReadInt32FromDynamic7Bit()
		{
			int value = 0;
			int byteCount = 0;
			bool readMore;
			do
			{
				byte byteValue = _bytes[_offset++];
				readMore = (byteValue & ReadMoreMask) == ReadMoreMask;
				value = value | (byteValue & (ReadMoreMask - 1)) << (7 * byteCount);
				byteCount++;
			} while (readMore && byteCount < 4);
			return value;
		}

		private List<string> ReadPropertyNames(int propertyCount)
		{
			var properties = new List<string>();
			for (int i = 0; i < propertyCount; i++)
			{
				properties.Add(ReadString());
			}
			return properties;
		}

		private List<byte> ReadPropertyValues(int propertyCount)
		{
			var propertyTypes = new List<byte>();
			for (int i = 0; i < propertyCount; i++)
			{
				propertyTypes.Add(_bytes[_offset++]);
			}
			return propertyTypes;
		}

		private string ReadString()
		{
			int length = ReadInt32FromDynamic7Bit();
			string readString = Encoding.ASCII.GetString(_bytes, _offset, length);
			_offset += length;
			return readString;
		}

		private void SkipAssemblyInfo()
		{
			_offset += 5;
			ReadString();
		}

		private void SkipClass()
		{
			_offset += 5;
			SkipTypeName();
			SkipProperties();
		}

		private void SkipEndOfObject()
		{
            _offset++;
		}

		private void SkipHeader()
		{
			_offset++;
			SkipInt32();
			SkipInt32();
			SkipInt32();
			SkipInt32();
		}

		private void SkipInt32()
		{
			_offset += 4;
		}

		private void SkipNullObject()
		{
			_offset++;
			_offset++;
		}

		private void SkipNamedObjectHierarchy()
		{
			_offset += 1 + 4;
			ReadString();
			while (_offset < _bytes.Length && !_found)
			{
				byte sectionType = _bytes[_offset];
				_sectionTypeActionMap[sectionType]();
				if (sectionType == 0x0a)
				{
					return;
				}
			}
		}

		private void SkipUnnamedObjectHierarchy()
		{
			_offset += 1 + 3;
			while (_offset < _bytes.Length && !_found)
			{
				byte sectionType = _bytes[_offset];
				_sectionTypeActionMap[sectionType]();
				if (sectionType == 0x0a)
				{
					return;
				}
			}
		}

		private void SkipProperties()
		{
			int propertyCount = _bytes[_offset];
			_offset += 4;
			var properties = ReadPropertyNames(propertyCount);
			var propertyTypes = ReadPropertyValues(propertyCount);

			var objectTypeNames = new List<string>();
			for (int i = 0; i < propertyCount; i++)
			{
				byte type = propertyTypes[i];
				if (type != 0x03)
				{
					continue;
				}
				objectTypeNames.Add(ReadString());
			}

			for (int i = 0; i < objectTypeNames.Count; i++)
			{
				byte type = _bytes[_offset];
				_sectionTypeActionMap[type]();
			}
            if (_bytes[_offset] == 0x0a)
            {
                SkipEndOfObject();
            }
			_found = true;

			return;
		}

		private void SkipString()
		{
			ReadString();
		}

		private void SkipTypeName()
		{
			ReadString();
		}
	}
}