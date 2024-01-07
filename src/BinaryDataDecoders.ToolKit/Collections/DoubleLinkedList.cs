using System;

namespace BinaryDataDecoders.ToolKit.Collections;

internal class DoubleLinkedList<T>(T item) : IDoubleLinkedList<T>
{
    private readonly object _lock = new();
    private int _position;

    public IDoubleLinkedList<T>? Previous { get; private set; }
    public T Current { get; } = item;
    public IDoubleLinkedList<T>? Next { get; private set; }

    public int Position => _position;

    private static void SyncPosition(DoubleLinkedList<T> from)
    {
        var seed = from._position;
        while (from?.Next is DoubleLinkedList<T> next)
        {
            next._position = ++seed;
            from = next;
        }
    }

    public IDoubleLinkedList<T> InsertBefore(T item)
    {
        lock (_lock)
        {
            var newItem = new DoubleLinkedList<T>(item) { Previous = this.Previous, Next = this };
            if (this.Previous is DoubleLinkedList<T> previous)
            {
                previous.Next = newItem;
                newItem._position = previous._position + 1;
            }
            else if (this.Previous != null)
            {
                throw new NotSupportedException();
            }
            this.Previous = newItem;
            SyncPosition(newItem);
            return newItem;
        }
    }
    public IDoubleLinkedList<T> InsertAfter(T item)
    {
        lock (_lock)
        {
            var newItem = new DoubleLinkedList<T>(item) { Previous = this, Next = this.Next, _position = this._position + 1, };
            if (this.Next is DoubleLinkedList<T> next)
            {
                next.Previous = newItem;
            }
            else if (this.Next != null)
            {
                throw new NotSupportedException();
            }
            this.Next = newItem;
            SyncPosition(newItem);
            return newItem;
        }
    }
}
