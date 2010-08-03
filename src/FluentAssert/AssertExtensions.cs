using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using FluentAssert.Exceptions;

using NUnit.Framework;

using AssertionException = FluentAssert.Exceptions.AssertionException;

namespace FluentAssert
{
	[DebuggerNonUserCode]
	[DebuggerStepThrough]
	public static class AssertExtensions
	{
		private static bool IsNull<T>(T expected)
		{
			object objectExpected = expected;
			return objectExpected == null;
		}

		public static Exception OfType<T>(this Exception item)
		{
			Assert.IsInstanceOf(typeof(T), item);
			return item;
		}

		public static IList<T> ShouldBeEmpty<T>(this IList<T> list)
		{
			list.ShouldNotBeNull();
			list.Count.ShouldBeEqualTo(0);
			return list;
		}

		public static IList<T> ShouldBeEqualTo<T>(this IList<T> list, IEnumerable<T> expected) where T : IEquatable<T>
		{
			list.ToList().ShouldContainAll(expected);
			expected.ToList().ShouldContainAll(list);
			return list;
		}

		public static T ShouldBeEqualTo<T>(this T item, T expected)
		{
			return ShouldBeEqualTo(item, expected, () => ShouldBeEqualAssertionException.CreateMessage(item, expected));
		}

		public static T ShouldBeEqualTo<T>(this T item, T expected, string errorMessage)
		{
			return ShouldBeEqualTo(item, expected, () => errorMessage);
		}

		public static T ShouldBeEqualTo<T>(this T item, T expected, Func<string> getErrorMessage)
		{
			if (getErrorMessage == null)
			{
				throw new ArgumentNullException("getErrorMessage", "the method used to get the error message cannot be null");
			}

			if (ReferenceEquals(item, expected))
			{
				return item;
			}

			bool itemIsNull = IsNull(item);
			bool expectedIsNull = IsNull(expected);

			if (itemIsNull && expectedIsNull)
			{
				return item;
			}
			if (itemIsNull || expectedIsNull || !item.Equals(expected))
			{
				throw new ShouldBeEqualAssertionException(getErrorMessage());
			}

			return item;
		}

		public static void ShouldBeFalse(this bool item)
		{
			ShouldBeFalse(item, ShouldBeFalseAssertionException.CreateMessage);
		}

		public static void ShouldBeFalse(this bool item, string errorMessage)
		{
			ShouldBeFalse(item, () => errorMessage);
		}

		public static void ShouldBeFalse(this bool item, Func<string> getErrorMessage)
		{
			if (getErrorMessage == null)
			{
				throw new ArgumentNullException("getErrorMessage", "the method used to get the error message cannot be null");
			}

			if (item)
			{
				throw new ShouldBeFalseAssertionException(getErrorMessage());
			}
		}

		public static T ShouldBeGreaterThan<T>(this T item, T lowEndOfRange) where T : IComparable
		{
			Assert.That(Is.GreaterThan(lowEndOfRange).Matches(item));
			return item;
		}

		public static T ShouldBeGreaterThan<T>(this T item, T lowEndOfRange, string errorMessage) where T : IComparable
		{
			Assert.That(Is.GreaterThan(lowEndOfRange).Matches(item), errorMessage);
			return item;
		}

		public static T ShouldBeGreaterThanOrEqualTo<T>(this T item, T lowEndOfRange) where T : IComparable
		{
			Assert.That(Is.GreaterThanOrEqualTo(lowEndOfRange).Matches(item));
			return item;
		}

		public static T ShouldBeInRangeInclusive<T>(this T item, T lowEndOfRange, T highEndOfRange)
			where T : IComparable
		{
			item.ShouldBeGreaterThanOrEqualTo(lowEndOfRange);
			item.ShouldBeLessThanOrEqualTo(highEndOfRange);
			return item;
		}

		public static T ShouldBeLessThan<T>(this T item, T highEndOfRange) where T : IComparable
		{
			Assert.That(Is.LessThan(highEndOfRange).Matches(item));
			return item;
		}

		public static T ShouldBeLessThanOrEqualTo<T>(this T item, T highEndOfRange) where T : IComparable
		{
			Assert.That(Is.LessThanOrEqualTo(highEndOfRange).Matches(item));
			return item;
		}

		public static T ShouldBeNull<T>(this T item)
		{
			Assert.IsNull(item);
			return item;
		}

		public static T ShouldBeNull<T>(this T item, string errorMessage) where T : class
		{
			Assert.IsNull(item, errorMessage);
			return item;
		}

		public static object ShouldBeOfType<TType>(this object item)
		{
			item.ShouldBeOfType<TType>("");
			return item;
		}

		public static object ShouldBeOfType<TType>(this object item, string errorMessage)
		{
			typeof(TType).IsAssignableFrom(item.GetType()).ShouldBeTrue(errorMessage);
			return item;
		}

		public static T ShouldBeSameInstanceAs<T>(this T item, T other)
		{
			ReferenceEquals(item, other).ShouldBeTrue();
			return item;
		}

		public static void ShouldBeTrue(this bool item)
		{
			ShouldBeTrue(item, ShouldBeTrueAssertionException.CreateMessage);
		}

		public static void ShouldBeTrue(this bool item, string errorMessage)
		{
			ShouldBeTrue(item, () => errorMessage);
		}

		public static void ShouldBeTrue(this bool item, Func<string> getErrorMessage)
		{
			if (getErrorMessage == null)
			{
				throw new ArgumentNullException("getErrorMessage", "the method used to get the error message cannot be null");
			}

			if (!item)
			{
				throw new ShouldBeTrueAssertionException(getErrorMessage());
			}
		}

		public static string ShouldContain(this string item, string expectedSubstring)
		{
			item.Contains(expectedSubstring).ShouldBeTrue();
			return item;
		}

		public static IList<T> ShouldContainAll<T>(this IList<T> list, IEnumerable<T> expected) where T : IEquatable<T>
		{
			foreach (var item in expected)
			{
				var other = item;
				list.Any(x => x.Equals(other)).ShouldBeTrue("Collection does not contain '" + item + "'");
			}
			return list;
		}

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

		public static string ShouldEndWith(this string item, string expected)
		{
			item.EndsWith(expected).ShouldBeTrue();
			return item;
		}

		public static string ShouldEndWith(this string item, string expected, string errorMessage)
		{
			item.EndsWith(expected).ShouldBeTrue(errorMessage);
			return item;
		}

		public static T ShouldNotBeEqualTo<T>(this T item, T expected)
		{
			return ShouldNotBeEqualTo(item, expected, () => ShouldNotBeEqualAssertionException.CreateMessage(item, expected));
		}

		public static T ShouldNotBeEqualTo<T>(this T item, T expected, string errorMessage)
		{
			return ShouldNotBeEqualTo(item, expected, () => errorMessage);
		}

		public static T ShouldNotBeEqualTo<T>(this T item, T expected, Func<string> getErrorMessage)
		{
			if (getErrorMessage == null)
			{
				throw new ArgumentNullException("getErrorMessage", "the method used to get the error message cannot be null");
			}

			if (ReferenceEquals(item, expected))
			{
				throw new ShouldNotBeEqualAssertionException(getErrorMessage());
			}

			bool itemIsNull = IsNull(item);
			bool expectedIsNull = IsNull(expected);

			if (itemIsNull && expectedIsNull ||
			    !itemIsNull && item.Equals(expected))
			{
				throw new ShouldNotBeEqualAssertionException(getErrorMessage());
			}

			return item;
		}

		public static T ShouldNotBeNull<T>(this T item) where T : class
		{
			return ShouldNotBeNull(item, ShouldNotBeNullAssertionException.CreateMessage);
		}

		public static T? ShouldNotBeNull<T>(this T? item) where T : struct
		{
			return ShouldNotBeNull(item, ShouldNotBeNullAssertionException.CreateMessage);
		}

		public static T ShouldNotBeNull<T>(this T item, string errorMessage) where T : class
		{
			return ShouldNotBeNull(item, () => errorMessage);
		}

		public static T ShouldNotBeNull<T>(this T item, Func<string> getErrorMessage) where T : class
		{
			if (getErrorMessage == null)
			{
				throw new ArgumentNullException("getErrorMessage", "the method used to get the error message cannot be null");
			}

			if (item == null)
			{
				throw new ShouldNotBeNullAssertionException(getErrorMessage());
			}
			return item;
		}

		public static T? ShouldNotBeNull<T>(this T? item, string errorMessage) where T : struct
		{
			return ShouldNotBeNull(item, () => errorMessage);
		}

		public static T? ShouldNotBeNull<T>(this T? item, Func<string> getErrorMessage) where T : struct
		{
			if (getErrorMessage == null)
			{
				throw new ArgumentNullException("getErrorMessage", "the method used to get the error message cannot be null");
			}

			if (!item.HasValue)
			{
				throw new ShouldNotBeNullAssertionException(getErrorMessage());
			}
			return item;
		}

		public static string ShouldNotBeNullOrEmpty(this string item)
		{
			item.ShouldNotBeNull();
			Assert.IsNotEmpty(item);
			return item;
		}

		public static string ShouldNotBeNullOrEmpty(this string item, string message)
		{
			item.ShouldNotBeNull(message);
			Assert.IsNotEmpty(item, message);
			return item;
		}

		public static T ShouldNotBeSameInstanceAs<T>(this T item, T other)
		{
			ReferenceEquals(item, other).ShouldBeFalse();
			return item;
		}

		public static string ShouldNotContain(this string item, string expectedSubstring)
		{
			item.Contains(expectedSubstring).ShouldBeFalse();
			return item;
		}

		public static string ShouldNotEndWith(this string item, string expected)
		{
			item.EndsWith(expected).ShouldBeFalse();
			return item;
		}

		public static string ShouldNotEndWith(this string item, string expected, string errorMessage)
		{
			item.EndsWith(expected).ShouldBeFalse(errorMessage);
			return item;
		}

		public static string ShouldNotStartWith(this string item, string expected)
		{
			item.StartsWith(expected).ShouldBeFalse();
			return item;
		}

		public static string ShouldNotStartWith(this string item, string expected, string errorMessage)
		{
			item.StartsWith(expected).ShouldBeFalse(errorMessage);
			return item;
		}

		public static string ShouldStartWith(this string item, string expected)
		{
			item.StartsWith(expected).ShouldBeTrue();
			return item;
		}

		public static string ShouldStartWith(this string item, string expected, string errorMessage)
		{
			item.StartsWith(expected).ShouldBeTrue(errorMessage);
			return item;
		}

		public static T ShouldThrow<T>(this T item, Func<T, object> methodToCall) where T : Exception
		{
			Assert.Throws<T>(() => methodToCall(item));
			return item;
		}

		public static T ShouldThrow<T>(this T item, Func<T, object> methodToCall, string exceptionMessage) where T : Exception
		{
			Assert.Throws<T>(() => methodToCall(item), exceptionMessage);
			return item;
		}

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
			throw new NUnit.Framework.AssertionException(String.Format("Should have thrown {0}.", typeof(T).Name));
		}

		[Obsolete("use item.ShouldThrow<TExceptionType>(x=>x.Method(args), \"Message\")")]
		public static Exception WithMessage(this Exception item, string expectedMessage)
		{
			item.Message.ShouldBeEqualTo(expectedMessage);
			return item;
		}
	}
}