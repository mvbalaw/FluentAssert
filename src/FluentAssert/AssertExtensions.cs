using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using NUnit.Framework;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	public static class AssertExtensions
	{
		[DebuggerNonUserCode]
		public static Exception OfType<T>(this Exception item)
		{
			Assert.IsInstanceOf(typeof(T), item);
			return item;
		}

		[DebuggerNonUserCode]
		public static IList<T> ShouldBeEmpty<T>(this IList<T> list)
		{
			list.ShouldNotBeNull();
			list.Count.ShouldBeEqualTo(0);
			return list;
		}

		[DebuggerNonUserCode]
		public static IList<T> ShouldBeEqualTo<T>(this IList<T> list, IEnumerable<T> expected) where T : IEquatable<T>
		{
			list.ToList().ShouldContainAll(expected);
			expected.ToList().ShouldContainAll(list);
			return list;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeEqualTo<T>(this T item, T expected)
		{
			Assert.AreEqual(expected, item);
			return item;
		}

		[DebuggerNonUserCode]
		public static T? ShouldBeEqualTo<T>(this T? item, T? expected) where T : struct
		{
			Assert.AreEqual(expected, item);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeEqualTo<T>(this T item, T expected, string errorMessage)
		{
			Assert.AreEqual(expected, item, errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static void ShouldBeFalse(this bool item)
		{
			Assert.IsFalse(item);
		}

		[DebuggerNonUserCode]
		public static void ShouldBeFalse(this bool item, string errorMessage)
		{
			Assert.IsFalse(item, errorMessage);
		}

		[DebuggerNonUserCode]
		public static T ShouldBeGreaterThan<T>(this T item, T lowEndOfRange) where T : IComparable
		{
			Assert.That(Is.GreaterThan(lowEndOfRange).Matches(item));
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeGreaterThan<T>(this T item, T lowEndOfRange, string errorMessage) where T : IComparable
		{
			Assert.That(Is.GreaterThan(lowEndOfRange).Matches(item), errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeGreaterThanOrEqualTo<T>(this T item, T lowEndOfRange) where T : IComparable
		{
			Assert.That(Is.GreaterThanOrEqualTo(lowEndOfRange).Matches(item));
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeInRangeInclusive<T>(this T item, T lowEndOfRange, T highEndOfRange)
			where T : IComparable
		{
			item.ShouldBeGreaterThanOrEqualTo(lowEndOfRange);
			item.ShouldBeLessThanOrEqualTo(highEndOfRange);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeLessThan<T>(this T item, T highEndOfRange) where T : IComparable
		{
			Assert.That(Is.LessThan(highEndOfRange).Matches(item));
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeLessThanOrEqualTo<T>(this T item, T highEndOfRange) where T : IComparable
		{
			Assert.That(Is.LessThanOrEqualTo(highEndOfRange).Matches(item));
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeNull<T>(this T item)
		{
			Assert.IsNull(item);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldBeNull<T>(this T item, string errorMessage) where T : class
		{
			Assert.IsNull(item, errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static object ShouldBeOfType<TType>(this object item)
		{
			item.ShouldBeOfType<TType>("");
			return item;
		}

		[DebuggerNonUserCode]
		public static object ShouldBeOfType<TType>(this object item, string errorMessage)
		{
			typeof(TType).IsAssignableFrom(item.GetType()).ShouldBeTrue(errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static void ShouldBeTrue(this bool item)
		{
			Assert.IsTrue(item);
		}

		[DebuggerNonUserCode]
		public static void ShouldBeTrue(this bool item, string errorMessage)
		{
			Assert.IsTrue(item, errorMessage);
		}

		[DebuggerNonUserCode]
		public static string ShouldContain(this string item, string expectedSubstring)
		{
			item.Contains(expectedSubstring).ShouldBeTrue();
			return item;
		}

		[DebuggerNonUserCode]
		public static IList<T> ShouldContainAll<T>(this IList<T> list, IEnumerable<T> expected) where T : IEquatable<T>
		{
			foreach (var item in expected)
			{
				var other = item;
				list.Any(x => x.Equals(other)).ShouldBeTrue("Collection does not contain '" + item + "'");
			}
			return list;
		}

		[DebuggerNonUserCode]
		public static IEnumerable<T> ShouldContainAllInOrder<T>(this IEnumerable<T> list, IEnumerable<T> expected) where T : IEquatable<T>
		{
			var indexedSource = list.Select((x, i) => new
				{
					Item = x,
					Index = i
				}).ToList();
			var indexedExpected = expected.Select((x, i) => new
				{
					Item = x,
					Index = i
				}).ToList();
			indexedSource.Count.ShouldBeEqualTo(indexedExpected.Count);
			foreach (int index in Enumerable.Range(0, indexedSource.Count))
			{
				indexedSource[index].Item.ShouldBeEqualTo(indexedExpected[index].Item, "at offset " + index);
			}
			return list;
		}

		[DebuggerNonUserCode]
		public static T ShouldNotBeEqualTo<T>(this T item, T expected)
		{
			Assert.AreNotEqual(expected, item);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldNotBeEqualTo<T>(this T item, T expected, string errorMessage)
		{
			Assert.AreNotEqual(expected, item, errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldNotBeNull<T>(this T item) where T : class
		{
			Assert.IsNotNull(item);
			return item;
		}

		[DebuggerNonUserCode]
		public static T? ShouldNotBeNull<T>(this T? item) where T : struct
		{
			Assert.IsTrue(item.HasValue);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldNotBeNull<T>(this T item, string errorMessage) where T : class
		{
			Assert.IsNotNull(item, errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static string ShouldNotBeNullOrEmpty(this string item)
		{
			Assert.IsNotNull(item);
			Assert.IsNotEmpty(item);
			return item;
		}

		[DebuggerNonUserCode]
		public static string ShouldNotBeNullOrEmpty(this string item, string message)
		{
			Assert.IsNotNull(item, message);
			Assert.IsNotEmpty(item, message);
			return item;
		}

		[DebuggerNonUserCode]
		public static string ShouldNotContain(this string item, string expectedSubstring)
		{
			item.Contains(expectedSubstring).ShouldBeFalse();
			return item;
		}

		[DebuggerNonUserCode]
		public static string ShouldStartWith(this string item, string expected, string errorMessage)
		{
			item.StartsWith(expected).ShouldBeTrue(errorMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldThrow<T>(this T item, Func<T, object> methodToCall) where T : Exception
		{
			Assert.Throws<T>(() => methodToCall(item));
			return item;
		}

		[DebuggerNonUserCode]
		public static T ShouldThrow<T>(this T item, Func<T, object> methodToCall, string exceptionMessage) where T : Exception
		{
			Assert.Throws<T>(() => methodToCall(item), exceptionMessage);
			return item;
		}

		[DebuggerNonUserCode]
		public static Exception ShouldThrowAnException<T>(this T item, Func<T, object> methodToCall) where T : Exception
		{
			try
			{
				methodToCall(item);
			}
			catch (Exception exception)
			{
				if (typeof(AssertionException).IsAssignableFrom(exception.GetType()))
				{
					throw;
				}
				return exception;
			}
			throw new AssertionException(String.Format("Should have thrown {0}.", typeof(T).Name));
		}

		[Obsolete("use item.ShouldThrow<TExceptionType>(x=>x.Method(args), \"Message\")")]
		[DebuggerNonUserCode]
		public static Exception WithMessage(this Exception item, string expectedMessage)
		{
			item.Message.ShouldBeEqualTo(expectedMessage);
			return item;
		}
	}
}