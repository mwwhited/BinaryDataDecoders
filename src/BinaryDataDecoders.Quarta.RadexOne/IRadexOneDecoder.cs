using System.Buffers;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    /// <summary>
    /// used to convert buffered data to correct value type
    /// </summary>
    public interface IRadexOneDecoder
    {
        /// <summary>
        /// used to convert buffered data to correct value type
        /// </summary>
        /// <param name="sequence">input data type</param>
        /// <returns>converted value type</returns>
        IRadexObject Decode(ReadOnlySequence<byte> sequence);
    }
}