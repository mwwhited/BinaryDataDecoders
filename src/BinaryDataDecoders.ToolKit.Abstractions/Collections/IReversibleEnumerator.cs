using System.Collections.Generic;

namespace BinaryDataDecoders.ToolKit.Collections
{
    /// <summary>
    /// Allow an Enumerable to move forwards or backwards
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReversibleEnumerator<T> : IEnumerator<T>
    {
        /// <summary>
        /// step current state of enumerator to previous element
        /// </summary>
        /// <returns>true if move was possible</returns>
        bool MovePrevious();

        /// <summary>
        /// current position of enumerator.  -1 if before head/reset
        /// </summary>
        int Position { get; }

        /// <summary>
        /// move enumerator last of previouslly read elements
        /// </summary>
        /// <returns>true if move was possible</returns>
        bool MoveCurrent();
    }
}
