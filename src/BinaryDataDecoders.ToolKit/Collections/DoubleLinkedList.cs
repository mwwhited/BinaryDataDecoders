using System;

namespace BinaryDataDecoders.ToolKit.Collections
{
    internal class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        public DoubleLinkedList(T item) => Current = item;

        public IDoubleLinkedList<T>? Previous { get; private set; }
        public T Current { get; }
        public IDoubleLinkedList<T>? Next { get; private set; }

        public IDoubleLinkedList<T> InsertBefore(T item)
        {
            var newItem = new DoubleLinkedList<T>(item) { Previous = this.Previous, Next = this };
            if (this.Previous is DoubleLinkedList<T> previous)
            {
                previous.Next = newItem;
            }
            else if (this.Previous != null)
            {
                throw new NotSupportedException();
            }
            this.Previous = newItem;
            return newItem;
        }
        public IDoubleLinkedList<T> InsertAfter(T item)
        {
            var newItem = new DoubleLinkedList<T>(item) { Previous = this, Next = this.Next };
            if (this.Next is DoubleLinkedList<T> next)
            {
                next.Previous = newItem;
            }
            else if (this.Next != null)
            {
                throw new NotSupportedException();
            }
            this.Next = newItem;
            return newItem;
        }
    }
}
