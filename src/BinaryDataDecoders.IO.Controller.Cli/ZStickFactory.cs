using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.Segmenters;
using System.IO.Ports;

namespace BinaryDataDecoders.IO.Controller.Cli;

[SerialPort(BaudRate = 115200)]
public class ZStickFactory
{
    public ISegmenter GetSegmenter(OnSegmentReceived received) =>
          Segment.StartsWith(0x06)
                 .AndIsLength(12)
                 .ExtendedWithLengthAt<ushort>(1, Endianness.Little)
                 .WithOptions(SegmentionOptions.SkipInvalidSegment)
                 .ThenDo(received);
}
