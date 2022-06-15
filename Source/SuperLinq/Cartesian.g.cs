namespace SuperLinq;

public static partial class SuperEnumerable
{
    /// <summary>
    /// Returns the Cartesian product of two sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        Func<T1, T2, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
                yield return resultSelector(item1, item2);
        }
    }

    /// <summary>
    /// Returns the Cartesian product of three sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="T3">
    /// The type of the elements of <paramref name="third"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="third">The third sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, T3, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        Func<T1, T2, T3, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        third.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();
            using var thirdMemo = third.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
            foreach (var item3 in thirdMemo)
                yield return resultSelector(item1, item2, item3);
        }
    }

    /// <summary>
    /// Returns the Cartesian product of four sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="T3">
    /// The type of the elements of <paramref name="third"/>.</typeparam>
    /// <typeparam name="T4">
    /// The type of the elements of <paramref name="fourth"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="third">The third sequence of elements.</param>
    /// <param name="fourth">The fourth sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        IEnumerable<T4> fourth,
        Func<T1, T2, T3, T4, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        third.ThrowIfNull();
        fourth.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();
            using var thirdMemo = third.Memoize();
            using var fourthMemo = fourth.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
            foreach (var item3 in thirdMemo)
            foreach (var item4 in fourthMemo)
                yield return resultSelector(item1, item2, item3, item4);
        }
    }

    /// <summary>
    /// Returns the Cartesian product of five sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="T3">
    /// The type of the elements of <paramref name="third"/>.</typeparam>
    /// <typeparam name="T4">
    /// The type of the elements of <paramref name="fourth"/>.</typeparam>
    /// <typeparam name="T5">
    /// The type of the elements of <paramref name="fifth"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="third">The third sequence of elements.</param>
    /// <param name="fourth">The fourth sequence of elements.</param>
    /// <param name="fifth">The fifth sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        IEnumerable<T4> fourth,
        IEnumerable<T5> fifth,
        Func<T1, T2, T3, T4, T5, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        third.ThrowIfNull();
        fourth.ThrowIfNull();
        fifth.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();
            using var thirdMemo = third.Memoize();
            using var fourthMemo = fourth.Memoize();
            using var fifthMemo = fifth.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
            foreach (var item3 in thirdMemo)
            foreach (var item4 in fourthMemo)
            foreach (var item5 in fifthMemo)
                yield return resultSelector(item1, item2, item3, item4, item5);
        }
    }

    /// <summary>
    /// Returns the Cartesian product of six sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="T3">
    /// The type of the elements of <paramref name="third"/>.</typeparam>
    /// <typeparam name="T4">
    /// The type of the elements of <paramref name="fourth"/>.</typeparam>
    /// <typeparam name="T5">
    /// The type of the elements of <paramref name="fifth"/>.</typeparam>
    /// <typeparam name="T6">
    /// The type of the elements of <paramref name="sixth"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="third">The third sequence of elements.</param>
    /// <param name="fourth">The fourth sequence of elements.</param>
    /// <param name="fifth">The fifth sequence of elements.</param>
    /// <param name="sixth">The sixth sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        IEnumerable<T4> fourth,
        IEnumerable<T5> fifth,
        IEnumerable<T6> sixth,
        Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        third.ThrowIfNull();
        fourth.ThrowIfNull();
        fifth.ThrowIfNull();
        sixth.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();
            using var thirdMemo = third.Memoize();
            using var fourthMemo = fourth.Memoize();
            using var fifthMemo = fifth.Memoize();
            using var sixthMemo = sixth.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
            foreach (var item3 in thirdMemo)
            foreach (var item4 in fourthMemo)
            foreach (var item5 in fifthMemo)
            foreach (var item6 in sixthMemo)
                yield return resultSelector(item1, item2, item3, item4, item5, item6);
        }
    }

    /// <summary>
    /// Returns the Cartesian product of seven sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="T3">
    /// The type of the elements of <paramref name="third"/>.</typeparam>
    /// <typeparam name="T4">
    /// The type of the elements of <paramref name="fourth"/>.</typeparam>
    /// <typeparam name="T5">
    /// The type of the elements of <paramref name="fifth"/>.</typeparam>
    /// <typeparam name="T6">
    /// The type of the elements of <paramref name="sixth"/>.</typeparam>
    /// <typeparam name="T7">
    /// The type of the elements of <paramref name="seventh"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="third">The third sequence of elements.</param>
    /// <param name="fourth">The fourth sequence of elements.</param>
    /// <param name="fifth">The fifth sequence of elements.</param>
    /// <param name="sixth">The sixth sequence of elements.</param>
    /// <param name="seventh">The seventh sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        IEnumerable<T4> fourth,
        IEnumerable<T5> fifth,
        IEnumerable<T6> sixth,
        IEnumerable<T7> seventh,
        Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        third.ThrowIfNull();
        fourth.ThrowIfNull();
        fifth.ThrowIfNull();
        sixth.ThrowIfNull();
        seventh.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();
            using var thirdMemo = third.Memoize();
            using var fourthMemo = fourth.Memoize();
            using var fifthMemo = fifth.Memoize();
            using var sixthMemo = sixth.Memoize();
            using var seventhMemo = seventh.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
            foreach (var item3 in thirdMemo)
            foreach (var item4 in fourthMemo)
            foreach (var item5 in fifthMemo)
            foreach (var item6 in sixthMemo)
            foreach (var item7 in seventhMemo)
                yield return resultSelector(item1, item2, item3, item4, item5, item6, item7);
        }
    }

    /// <summary>
    /// Returns the Cartesian product of eight sequences by enumerating all
    /// possible combinations of one item from each sequence, and applying
    /// a user-defined projection to the items in a given combination.
    /// </summary>
    /// <typeparam name="T1">
    /// The type of the elements of <paramref name="first"/>.</typeparam>
    /// <typeparam name="T2">
    /// The type of the elements of <paramref name="second"/>.</typeparam>
    /// <typeparam name="T3">
    /// The type of the elements of <paramref name="third"/>.</typeparam>
    /// <typeparam name="T4">
    /// The type of the elements of <paramref name="fourth"/>.</typeparam>
    /// <typeparam name="T5">
    /// The type of the elements of <paramref name="fifth"/>.</typeparam>
    /// <typeparam name="T6">
    /// The type of the elements of <paramref name="sixth"/>.</typeparam>
    /// <typeparam name="T7">
    /// The type of the elements of <paramref name="seventh"/>.</typeparam>
    /// <typeparam name="T8">
    /// The type of the elements of <paramref name="eighth"/>.</typeparam>
    /// <typeparam name="TResult">
    /// The type of the elements of the result sequence.</typeparam>
    /// <param name="first">The first sequence of elements.</param>
    /// <param name="second">The second sequence of elements.</param>
    /// <param name="third">The third sequence of elements.</param>
    /// <param name="fourth">The fourth sequence of elements.</param>
    /// <param name="fifth">The fifth sequence of elements.</param>
    /// <param name="sixth">The sixth sequence of elements.</param>
    /// <param name="seventh">The seventh sequence of elements.</param>
    /// <param name="eighth">The eighth sequence of elements.</param>
    /// <param name="resultSelector">A projection function that combines
    /// elements from all of the sequences.</param>
    /// <returns>A sequence of elements returned by
    /// <paramref name="resultSelector"/>.</returns>
    /// <remarks>
    /// <para>
    /// The method returns items in the same order as a nested foreach
    /// loop, but all sequences except for <paramref name="first"/> are
    /// cached when iterated over. The cache is then re-used for any
    /// subsequent iterations.</para>
    /// <para>
    /// This method uses deferred execution and stream its results.</para>
    /// </remarks>

    public static IEnumerable<TResult> Cartesian<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this IEnumerable<T1> first,
        IEnumerable<T2> second,
        IEnumerable<T3> third,
        IEnumerable<T4> fourth,
        IEnumerable<T5> fifth,
        IEnumerable<T6> sixth,
        IEnumerable<T7> seventh,
        IEnumerable<T8> eighth,
        Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
    {
        first.ThrowIfNull();
        second.ThrowIfNull();
        third.ThrowIfNull();
        fourth.ThrowIfNull();
        fifth.ThrowIfNull();
        sixth.ThrowIfNull();
        seventh.ThrowIfNull();
        eighth.ThrowIfNull();
        resultSelector.ThrowIfNull();

        return _(); IEnumerable<TResult> _()
        {
            using var secondMemo = second.Memoize();
            using var thirdMemo = third.Memoize();
            using var fourthMemo = fourth.Memoize();
            using var fifthMemo = fifth.Memoize();
            using var sixthMemo = sixth.Memoize();
            using var seventhMemo = seventh.Memoize();
            using var eighthMemo = eighth.Memoize();

            foreach (var item1 in first)
            foreach (var item2 in secondMemo)
            foreach (var item3 in thirdMemo)
            foreach (var item4 in fourthMemo)
            foreach (var item5 in fifthMemo)
            foreach (var item6 in sixthMemo)
            foreach (var item7 in seventhMemo)
            foreach (var item8 in eighthMemo)
                yield return resultSelector(item1, item2, item3, item4, item5, item6, item7, item8);
        }
    }
}
