using System;

namespace BinaryDataDecoders.IO.Pipelines.Definitions
{
    public class SegmentExtensionDefinition
    {
        public SegmentExtensionDefinition(Type type, int length, long postion, Endianness endianness)
        {
            Type = type;
            Length = length;
            Postion = postion;
            Endianness = endianness;
        }

        public Type Type { get; }
        public int Length { get; }
        public long Postion { get; }
        public Endianness Endianness { get; }
    }
}