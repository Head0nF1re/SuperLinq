﻿using System.Diagnostics;

namespace SuperLinq;

public static partial class SuperEnumerable
{
	/// <summary>
	/// Returns the elements of the specified sequence or the specified
	/// value in a singleton collection if the sequence is empty.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the sequences.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="fallback">The value to return in a singleton
	/// collection if <paramref name="source"/> is empty.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that contains <paramref name="fallback"/>
	/// if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
	/// </returns>
	/// <example>
	/// <code><![CDATA[
	/// var numbers = new[] { 123, 456, 789 };
	/// var result = numbers.Where(x => x == 100).FallbackIfEmpty(-1).Single();
	/// ]]></code>
	/// The <c>result</c> variable will contain <c>-1</c>.
	/// </example>

	public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback)
	{
		source.ThrowIfNull();
		return FallbackIfEmptyImpl(source, 1, fallback, default, default, default, null);
	}

	/// <summary>
	/// Returns the elements of a sequence, but if it is empty then
	/// returns an alternate sequence of values.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the sequences.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="fallback1">First value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <param name="fallback2">Second value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that containing fallback values
	/// if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
	/// </returns>

	public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2)
	{
		source.ThrowIfNull();
		return FallbackIfEmptyImpl(source, 2, fallback1, fallback2, default, default, null);
	}

	/// <summary>
	/// Returns the elements of a sequence, but if it is empty then
	/// returns an alternate sequence of values.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the sequences.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="fallback1">First value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <param name="fallback2">Second value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <param name="fallback3">Third value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that containing fallback values
	/// if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
	/// </returns>

	public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3)
	{
		source.ThrowIfNull();
		return FallbackIfEmptyImpl(source, 3, fallback1, fallback2, fallback3, default, null);
	}

	/// <summary>
	/// Returns the elements of a sequence, but if it is empty then
	/// returns an alternate sequence of values.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the sequences.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="fallback1">First value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <param name="fallback2">Second value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <param name="fallback3">Third value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <param name="fallback4">Fourth value of the alternate sequence that
	/// is returned if <paramref name="source"/> is empty.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that containing fallback values
	/// if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
	/// </returns>

	public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, T fallback1, T fallback2, T fallback3, T fallback4)
	{
		source.ThrowIfNull();
		return FallbackIfEmptyImpl(source, 4, fallback1, fallback2, fallback3, fallback4, null);
	}

	/// <summary>
	/// Returns the elements of a sequence, but if it is empty then
	/// returns an alternate sequence from an array of values.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the sequences.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="fallback">The array that is returned as the alternate
	/// sequence if <paramref name="source"/> is empty.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that containing fallback values
	/// if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
	/// </returns>

	public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, params T[] fallback)
	{
		source.ThrowIfNull();
		fallback.ThrowIfNull();
		return source.FallbackIfEmpty((IEnumerable<T>)fallback);
	}

	/// <summary>
	/// Returns the elements of a sequence, but if it is empty then
	/// returns an alternate sequence of values.
	/// </summary>
	/// <typeparam name="T">The type of the elements in the sequences.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="fallback">The alternate sequence that is returned
	/// if <paramref name="source"/> is empty.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that containing fallback values
	/// if <paramref name="source"/> is empty; otherwise, <paramref name="source"/>.
	/// </returns>

	public static IEnumerable<T> FallbackIfEmpty<T>(this IEnumerable<T> source, IEnumerable<T> fallback)
	{
		source.ThrowIfNull();
		fallback.ThrowIfNull();
		return FallbackIfEmptyImpl(source, null, default, default, default, default, fallback);
	}

	static IEnumerable<T> FallbackIfEmptyImpl<T>(IEnumerable<T> source,
		int? count, T? fallback1, T? fallback2, T? fallback3, T? fallback4,
		IEnumerable<T>? fallback)
	{
		return source.TryGetCollectionCount() is { } collectionCount
			 ? collectionCount == 0 ? Fallback() : source
			 : _();

		IEnumerable<T> _()
		{
			using (var e = source.GetEnumerator())
			{
				if (e.MoveNext())
				{
					do { yield return e.Current; }
					while (e.MoveNext());
					yield break;
				}
			}

			foreach (var item in Fallback())
				yield return item;
		}

		IEnumerable<T> Fallback()
		{
			return fallback is { } seq ? seq : FallbackOnArgs();

			IEnumerable<T> FallbackOnArgs()
			{
				Debug.Assert(count >= 1 && count <= 4);

				yield return fallback1!;
				if (count > 1) yield return fallback2!;
				if (count > 2) yield return fallback3!;
				if (count > 3) yield return fallback4!;
			}
		}
	}
}
