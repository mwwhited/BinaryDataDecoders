using System.Buffers;

namespace BinaryDataDecoders.IO.Segmenters
{
    internal class PassThroughSegmenter : SegmenterBase
    {
        private readonly long _minimumLength;

        public PassThroughSegmenter(OnSegmentReceived onSegmentReceived, long minimumLength, SegmentionOptions options)
            : base(onSegmentReceived, options)
        {
            _minimumLength = minimumLength;
        }

        protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer) =>
            buffer.Length switch
            {
                0 => (SegmentationStatus.Incomplete, buffer),
                _ when buffer.Length < _minimumLength => (SegmentationStatus.Invalid, buffer),
                _ => (SegmentationStatus.Complete, buffer)
            };
    }
}