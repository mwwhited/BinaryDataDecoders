using System;

namespace BinaryDataDecoders.IO.Pipelines
{
    [Flags]
    public enum SegmentionOptions
    {
        None = 0,
        SkipInvalidSegment = 1,
        SecondStartInvalid = 2,
    }
}