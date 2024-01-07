using System;

namespace BinaryDataDecoders.IO.Segmenters;

public class SegmentExtensionDefinition(Type type, int length, long postion, Endianness endianness)
{
    public Type Type { get; } = type;
    public int Length { get; } = length;
    public long Postion { get; } = postion;
    public Endianness Endianness { get; } = endianness;
}