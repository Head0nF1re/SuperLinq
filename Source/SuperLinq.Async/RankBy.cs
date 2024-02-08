﻿namespace SuperLinq.Async;

public static partial class AsyncSuperEnumerable
{
	/// <summary>
	/// Ranks each item in the sequence in ascending order by a specified key
	/// using a default comparer. The rank is equal to index + 1 of the first
	/// next different item, the first item has a rank of 1 (index 0 + 1).
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the source sequence</typeparam>
	/// <typeparam name="TKey">The type of the key used to rank items in the sequence</typeparam>
	/// <param name="source">The sequence of items to rank</param>
	/// <param name="keySelector">A key selector function which returns the value by which to rank items in the sequence</param>
	/// <returns>A sorted sequence of items and their rank.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
	public static IAsyncEnumerable<(TSource item, int rank)> RankBy<TSource, TKey>(
		this IAsyncEnumerable<TSource> source, Func<TSource, TKey> keySelector)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(keySelector);

		return RankCore(source, keySelector, comparer: null, isDense: false);
	}

	/// <summary>
	/// Ranks each item in the sequence in the order defined by <paramref name="sortDirection"/>
	/// by a specified key using a default comparer. The rank is equal to index + 1 of the first
	/// next different item, the first item has a rank of 1 (index 0 + 1).
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the source sequence</typeparam>
	/// <typeparam name="TKey">The type of the key used to rank items in the sequence</typeparam>
	/// <param name="source">The sequence of items to rank</param>
	/// <param name="keySelector">A key selector function which returns the value by which to rank items in the sequence</param>
	/// <param name="sortDirection">Defines the ordering direction for the sequence</param>
	/// <returns>A sorted sequence of items and their rank.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
	public static IAsyncEnumerable<(TSource item, int rank)> RankBy<TSource, TKey>(
		this IAsyncEnumerable<TSource> source,
		Func<TSource, TKey> keySelector,
		OrderByDirection sortDirection)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(keySelector);

		return RankCore(source, keySelector, comparer: null, isDense: false, sortDirection);
	}

	/// <summary>
	/// Ranks each item in the sequence in ascending order by a specified key
	/// using a caller-supplied comparer. The rank is equal to index + 1 of the first
	/// next different item, the first item has a rank of 1 (index 0 + 1).
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the source sequence</typeparam>
	/// <typeparam name="TKey">The type of the key used to rank items in the sequence</typeparam>
	/// <param name="source">The sequence of items to rank</param>
	/// <param name="keySelector">A key selector function which returns the value by which to rank items in the sequence</param>
	/// <param name="comparer">An object that defines the comparison semantics for keys used to rank items</param>
	/// <returns>A sorted sequence of items and their rank.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
	public static IAsyncEnumerable<(TSource item, int rank)> RankBy<TSource, TKey>(
		this IAsyncEnumerable<TSource> source,
		Func<TSource, TKey> keySelector,
		IComparer<TKey> comparer)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(keySelector);

		return RankCore(source, keySelector, comparer, isDense: false);
	}

	/// <summary>
	/// Ranks each item in the sequence in the order defined by <paramref name="sortDirection"/>
	/// by a specified key using a caller-supplied comparer. The rank is equal to index + 1 of the first
	/// next different item, the first item has a rank of 1 (index 0 + 1).
	/// </summary>
	/// <typeparam name="TSource">The type of the elements in the source sequence</typeparam>
	/// <typeparam name="TKey">The type of the key used to rank items in the sequence</typeparam>
	/// <param name="source">The sequence of items to rank</param>
	/// <param name="keySelector">A key selector function which returns the value by which to rank items in the sequence</param>
	/// <param name="comparer">An object that defines the comparison semantics for keys used to rank items</param>
	/// <param name="sortDirection">Defines the ordering direction for the sequence</param>
	/// <returns>A sorted sequence of items and their rank.</returns>
	/// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentNullException"><paramref name="keySelector"/> is <see langword="null"/>.</exception>
	public static IAsyncEnumerable<(TSource item, int rank)> RankBy<TSource, TKey>(
		this IAsyncEnumerable<TSource> source,
		Func<TSource, TKey> keySelector,
		IComparer<TKey> comparer,
		OrderByDirection sortDirection)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(keySelector);

		return RankCore(source, keySelector, comparer, isDense: false, sortDirection);
	}
}
