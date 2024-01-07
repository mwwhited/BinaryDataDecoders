using System;

namespace BinaryDataDecoders.IO.Functions;

public interface IChecksumCalculator
{
    ushort Simple16(ReadOnlySpan<ushort> buffer);
}