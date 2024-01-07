namespace BinaryDataDecoders.ToolKit.Collections;

/// <summary>
/// interface for a double linked list
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDoubleLinkedList<T>
{
    /// <summary>
    /// previous segment for double linked list
    /// </summary>
    IDoubleLinkedList<T>? Previous { get; }
    /// <summary>
    /// current element
    /// </summary>
    T Current { get; }
    /// <summary>
    /// next segment for double linked list
    /// </summary>
    IDoubleLinkedList<T>? Next { get; }

    IDoubleLinkedList<T> InsertBefore(T item);
    IDoubleLinkedList<T> InsertAfter(T item);

    int Position { get; }
}
