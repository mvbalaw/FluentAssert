using System.Linq;
using System.Reflection;

namespace FluentAssert.Tests
{
	public static class EmbeddedResource
	{
		public static byte[] Read(string resourceName)
		{
			var asm = Assembly.GetExecutingAssembly();
			string name = asm.GetManifestResourceNames().First(x => x.EndsWith("." + resourceName));
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