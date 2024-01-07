using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit.Collections;

/// <summary>
/// Custom extensions for IEnumerable
/// </summary>
public static class EnumerableEx
{
    /// <summary>
    /// expose IEnumerable a reversible enumerator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerable"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> GetReversibleEnumerator<T>(this IEnumerable<T> enumerable) => new ReversableEnumerator<T>(enumerable);
    /// <summary>
    /// convert enumerator to a reversible enumerator 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> MakeReversibleEnumerator<T>(this IEnumerator<T> enumerator) => new ReversableEnumerator<T>(enumerator);
}
