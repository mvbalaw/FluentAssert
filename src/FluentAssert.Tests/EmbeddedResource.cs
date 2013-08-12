//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution. 
//  * By using this source code in any fashion, you are agreeing to be bound by 
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System.Linq;
using System.Reflection;

namespace FluentAssert.Tests
{
	public static class EmbeddedResource
	{
		public static byte[] Read(string resourceName)
		{
			var asm = Assembly.GetExecutingAssembly();
			var name = asm.GetManifestResourceNames().First(x => x.EndsWith("." + resourceName));
			using (var stream = asm.GetManifestResourceStream(name))
			{
// ReSharper disable PossibleNullReferenceException
				var bytes = new byte[stream.Length];
// ReSharper restore PossibleNullReferenceException
				stream.Read(bytes, 0, bytes.Length);
				return bytes;
			}
		}
	}
}