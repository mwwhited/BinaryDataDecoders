namespace BinaryDataDecoders.ToolKit.Collections;

public static class ReversibleEnumeratorEx
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> Rewind<T>(this IReversibleEnumerator<T> current)
    {
        current.Reset();
        return current;
    }

    /// <summary>
    /// move to last element in cache
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> FastForward<T>(this IReversibleEnumerator<T> current)
    {
        current.MoveCurrent();
        return current;
    }

    /// <summary>
    /// move to last element in IDoubleLinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> FastForwardToEnd<T>(this IReversibleEnumerator<T> current)
    {
        while (current.MoveNext()) ;
        return current;
    }

    /// <summary>
    /// try moving to realative position
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> Offset<T>(this IReversibleEnumerator<T> current, int count) =>
        count switch
        {
            _ when count > 0 => current.Forward(count),
            _ when count < 0 => current.Back(count * -1),
            _ => current
        };

    /// <summary>
    /// move backwards at least count steps
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> Back<T>(this IReversibleEnumerator<T> current, int count)
    {
        for (var i = 0; i < count && current.MovePrevious(); i++) ;
        return current;
    }

    /// <summary>
    /// move forwards at least count steps
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="current"></param>
    /// <param name="count"></param>
    /// <returns></returns>
    public static IReversibleEnumerator<T> Forward<T>(this IReversibleEnumerator<T> current, int count)
    {
        for (var i = 0; i < count && current.MoveNext(); i++) ;
        return current;
    }
}
