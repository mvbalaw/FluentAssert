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
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace FluentAssert.Exceptions.Rewriting
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public class ExceptionRewriter
	{
		private static Exception Deserialize(byte[] bytes)
		{
			var bf = new BinaryFormatter();
			var stream = new MemoryStream(bytes);
			var result = (Exception)bf.Deserialize(stream);
			stream.Close();
			return result;
		}

		private static void FindStackTraceSegment(MemoryStream stream)
		{
			stream.Position = 0;
			new BinarySerializationHeaderSegment().Skip(stream);
			var assemblyInfoSegment = BinarySerializationSegment.AssemblyInfoSegment.Handler;
			if (assemblyInfoSegment.IsMatch(stream))
			{
				assemblyInfoSegment.Skip(stream);
			}
			var exceptionClassSegment = new BinarySerializationPartialExceptionClassSegment();
			if (!exceptionClassSegment.IsMatch(stream))
			{
				throw new ArgumentException(String.Format("don't know how to handle segment type '0x{0:x2}'", stream.PeekByte()));
			}
			exceptionClassSegment.Skip(stream);
			exceptionClassSegment.SkipPrefix(stream);
		}

		public Exception RewriteStacktrace(Exception exception)
		{
			var stream = Serialize(exception);
			FindStackTraceSegment(stream);
			int stackTraceStart = (int)stream.Position;
			string stackTrace = stream.ReadStringHaving7bitVariableLengthInt32Prefix();
			int stackTraceEnd = (int)stream.Position;
			stackTrace = RemoveSegmentFromStacktrace(stackTrace);
			stream.Position = 0;
			var bytes = stream.ToArray().ToList();
			TransferUpdatedStacktraceToException(stackTrace, bytes, stackTraceStart, stackTraceEnd);

			var result = Deserialize(bytes.ToArray());
			return result;
		}

		private static string RemoveSegmentFromStacktrace(string stackTrace)
		{
			var originalTraceLines = stackTrace.Split(new[] { "\r\n" }, StringSplitOptions.None);
			var callingAssembly = Assembly.GetCallingAssembly();
			var result = new List<string>();

			int? lastFluentAssert = null;
			for (int i = 0; i < originalTraceLines.Length; i++)
			{
				var line = originalTraceLines[i];
				var paren = line.IndexOf('(');
				if (paren == -1)
				{
					lastFluentAssert = null;
					result.Add(line);
					continue;
				}
				line = line.Substring(0, paren);
				var generic = line.IndexOf(".<");
				if (generic != -1)
				{
					line = line.Substring(0, generic+1);
				}
				var dot = line.LastIndexOf('.');
				if (dot == -1)
				{
					lastFluentAssert = null;
					result.Add(originalTraceLines[i]);
					continue;
				}
				var lastSpace = line.LastIndexOf(' ')+1;
				var className = line.Substring(lastSpace, dot-lastSpace);
				if (callingAssembly.GetType(className, false) != null)
				{
					lastFluentAssert = i;
					continue;
				}

				if (lastFluentAssert != null)
				{
					var systemIndex = line.IndexOf("  at System.");
					var isSystem = systemIndex < 2 && systemIndex > -1;
					if (isSystem)
					{
						continue;
					}
					result.Add(originalTraceLines[lastFluentAssert.Value]);
					lastFluentAssert = null;
				}
				result.Add(originalTraceLines[i]);
			}

			if (lastFluentAssert != null)
			{
				result.Add(originalTraceLines[lastFluentAssert.Value]);
			}

			return String.Join("\r\n", result.ToArray());
		}

		private static void TransferUpdatedStacktraceToException(string stackTrace, List<byte> bytes, int stackTraceStart, int stackTraceEnd)
		{
			var stackTraceBytes = Encoding.ASCII.GetBytes(stackTrace);
			var encodedRevisedStackTraceLength = stackTraceBytes.Length.To7bitVariableLengthByteArray();
			int position = stackTraceStart;

			foreach (byte b in encodedRevisedStackTraceLength)
			{
				bytes[position++] = b;
			}
			foreach (byte b in stackTraceBytes)
			{
				bytes[position++] = b;
			}

			bytes.RemoveRange(position, stackTraceEnd - position);
		}

		private static MemoryStream Serialize(Exception exception)
		{
			var stream = new MemoryStream();
			var bf = new BinaryFormatter();
			bf.Serialize(stream, exception);
			stream.Flush();
			return stream;
		}
	}
}