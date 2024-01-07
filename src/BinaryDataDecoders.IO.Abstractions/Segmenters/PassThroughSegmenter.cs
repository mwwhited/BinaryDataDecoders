using System.Buffers;

namespace BinaryDataDecoders.IO.Segmenters;

internal class PassThroughSegmenter(OnSegmentReceived onSegmentReceived, long minimumLength, SegmentionOptions options) : SegmenterBase(onSegmentReceived, options)
{
    protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer) =>
        buffer.Length switch
        {
            0 => (SegmentationStatus.Incomplete, buffer),
            _ when buffer.Length < minimumLength => (SegmentationStatus.Invalid, buffer),
            _ => (SegmentationStatus.Complete, buffer)
        };
}