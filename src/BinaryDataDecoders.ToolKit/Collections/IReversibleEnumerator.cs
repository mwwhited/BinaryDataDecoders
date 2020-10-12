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
    }
}
