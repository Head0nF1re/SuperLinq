﻿namespace SuperLinq;

public static partial class SuperEnumerable
{
	/// <summary>
	/// Interleaves the elements of two or more sequences into a single sequence, skipping sequences as they are consumed
	/// </summary>
	/// <remarks>
	/// Interleave combines sequences by visiting each in turn, and returning the first element of each, followed
	/// by the second, then the third, and so on. So, for example:<br/>
	/// <code><![CDATA[
	/// {1,1,1}.Interleave( {2,2,2}, {3,3,3} ) => { 1,2,3,1,2,3,1,2,3 }
	/// ]]></code>
	/// This operator behaves in a deferred and streaming manner.<br/>
	/// When sequences are of unequal length, this method will skip those sequences that have been fully consumed
	/// and continue interleaving the remaining sequences.<br/>
	/// The sequences are interleaved in the order that they appear in the <paramref name="otherSequences"/>
	/// collection, with <paramref name="sequence"/> as the first sequence.
	/// </remarks>
	/// <typeparam name="T">The type of the elements of the source sequences</typeparam>
	/// <param name="sequence">The first sequence in the interleave group</param>
	/// <param name="otherSequences">The other sequences in the interleave group</param>
	/// <returns>A sequence of interleaved elements from all of the source sequences</returns>

	public static IEnumerable<T> Interleave<T>(this IEnumerable<T> sequence, params IEnumerable<T>[] otherSequences)
	{
		sequence.ThrowIfNull();
		otherSequences.ThrowIfNull();
		if (otherSequences.Any(s => s == null))
			throw new ArgumentNullException(nameof(otherSequences), "One or more sequences passed to Interleave was null.");

		return _(); IEnumerable<T> _()
		{
			var sequences = new[] { sequence }.Concat(otherSequences);
			var enumerators = new List<IEnumerator<T>?>();

			try
			{
				foreach (var enumerator in sequences.Select(s => s.GetEnumerator()))
				{
					enumerators.Add(enumerator);
					if (enumerator.MoveNext())
					{
						yield return enumerator.Current;
					}
					else
					{
						enumerators.Remove(enumerator);
						enumerator.Dispose();
					}
				}

				var hasNext = true;
				while (hasNext)
				{
					hasNext = false;
					for (var i = 0; i < enumerators.Count; i++)
					{
						var enumerator = enumerators[i];
						if (enumerator == null)
							continue;

						if (enumerator.MoveNext())
						{
							hasNext = true;
							yield return enumerator.Current;
						}
						else
						{
							enumerators[i] = null;
							enumerator.Dispose();
						}
					}
				}
			}
			finally
			{
				foreach (var enumerator in enumerators)
					enumerator?.Dispose();
			}
		}
	}
}
