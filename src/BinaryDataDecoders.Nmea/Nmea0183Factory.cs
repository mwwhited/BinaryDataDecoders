using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.ToolKit;
using System;

namespace BinaryDataDecoders.Nmea
{
    public class Nmea0183Factory : INmea0183Factory
    {
        public ISegmenter GetSegmenter(OnSegmentReceived thenDo) => Segment.StartsWith(Bytes._S).AndEndsWith(Bytes.Lf).ThenDo(thenDo);
    }
}
