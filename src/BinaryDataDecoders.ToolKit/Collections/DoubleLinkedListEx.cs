using System;
using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit.Collections
{
    /// <summary>
    /// Extensions for IDoubleLinkedList
    /// </summary>
    internal static class DoubleLinkedListEx
    {
        /// <summary>
        /// move for first element in IDoubleLinkedList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <returns></returns>
        public static IDoubleLinkedList<T> Rewind<T>(this IDoubleLinkedList<T> current)
        {
            while (current.Previous != null) current = current.Previous ?? throw new NullReferenceException();
            return current;
        }
        /// <summary>
        /// move to last element in IDoubleLinkedList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <returns></returns>
        public static IDoubleLinkedList<T> FastForward<T>(this IDoubleLinkedList<T> current)
        {
            while (current.Next != null) current = current.Next ?? throw new NullReferenceException();
            return current;
        }

        /// <summary>
        /// try moving to realative position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IDoubleLinkedList<T> Offset<T>(this IDoubleLinkedList<T> current, int count) =>
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
        public static IDoubleLinkedList<T> Back<T>(this IDoubleLinkedList<T> current, int count)
        {
            while (current.Previous != null && count-- > 0) current = current.Previous ?? throw new NullReferenceException();
            return current;
        }

        /// <summary>
        /// move forwards at least count steps
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="current"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IDoubleLinkedList<T> Forward<T>(this IDoubleLinkedList<T> current, int count)
        {
            while (current.Next != null && count-- > 0) current = current.Next ?? throw new NullReferenceException();
            return current;
        }

        public static IEnumerable<T> Play<T>(this IDoubleLinkedList<T> current)
        {
            IDoubleLinkedList<T>? list = current;
            if (list == null) yield break;
            do
            {
                yield return list.Current;
                list = list.Next;
            }
            while (list?.Next != null);
        }
        public static IEnumerable<T> PlayBackwards<T>(this IDoubleLinkedList<T> current)
        {
            IDoubleLinkedList<T>? list = current;
            if (list == null) yield break;
            do
            {
                yield return list.Current;
                list = list.Previous;
            }
            while (list?.Previous != null);
        }
    }
}
