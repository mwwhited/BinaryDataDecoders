using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Pipelines
{
    public abstract class SegmentedHandlerBase : ISegmenter
    {
        protected SegmentedHandlerBase(OnSegmentReceived onSegmentReceived)
        {
            OnSegmentReceived = onSegmentReceived;
        }

        private OnSegmentReceived OnSegmentReceived { get; }

        public async Task<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer)
        {
            var segment = Read(buffer);
            if (segment != null)
            {
                await OnSegmentReceived(segment.Value);
                buffer = buffer.Slice(buffer.GetPosition(1, segment.Value.End));
            }

            return new SegmentReadResult(buffer.Length > 0, buffer);
        }

        protected abstract ReadOnlySequence<byte>? Read(ReadOnlySequence<byte> buffer);
    }


    // Target Start Byte, Fixed Length

}