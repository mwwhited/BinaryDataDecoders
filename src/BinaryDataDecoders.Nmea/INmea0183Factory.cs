using BinaryDataDecoders.IO.Pipelines;

namespace BinaryDataDecoders.Nmea
{
    public interface INmea0183Factory
    {
        ISegmenter GetSegmenter(OnSegmentReceived thenDo);
    }
}