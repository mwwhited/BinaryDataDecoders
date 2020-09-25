using System;
using System.Buffers;
using System.Runtime.InteropServices;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    /// <summary>
    /// used to convert buffered data to correct value type
    /// </summary>
    public class RadexOneDecoder : IRadexOneDecoder
    {
        /// <summary>
        /// used to convert buffered data to correct value type
        /// </summary>
        /// <param name="sequence">input data type</param>
        /// <returns>converted value type</returns>
        public IRadexObject Decode(ReadOnlySequence<byte> sequence)
        {
            Span<byte> data = new byte[sequence.Length];
            sequence.CopyTo(data);
            var values = MemoryMarshal.Cast<byte, ushort>(data);

            return values[2] switch
            {
                0 => MemoryMarshal.Cast<byte, DevicePing>(data)[0],
                _ => values[6] switch
                {
                    0x00_01 => MemoryMarshal.Cast<byte, ReadSerialNumberResponse>(data)[0],
                    0x08_00 => MemoryMarshal.Cast<byte, ReadValuesResponse>(data)[0],
                    0x08_01 => MemoryMarshal.Cast<byte, ReadSettingsResponse>(data)[0],
                    0x08_02 => MemoryMarshal.Cast<byte, WriteSettingsResponse>(data)[0],
                    0x08_03 => MemoryMarshal.Cast<byte, ResetAccumulatedResponse>(data)[0],
                    _ => throw new NotSupportedException($"Object type: {values[6]: X2} unknown")
                }
            };
        }
    }
}
