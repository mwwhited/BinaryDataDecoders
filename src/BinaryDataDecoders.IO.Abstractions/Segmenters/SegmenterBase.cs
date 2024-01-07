using System;
using System.Buffers;
using System.Threading.Tasks;

namespace BinaryDataDecoders.IO.Segmenters;

public abstract class SegmenterBase : ISegmenter
{
    protected SegmenterBase(
        OnSegmentReceived onSegmentReceived,
        SegmentionOptions options
        )
    {
        OnSegmentReceived = onSegmentReceived;
        Options = options;
    }

    private OnSegmentReceived OnSegmentReceived { get; }
    public SegmentionOptions Options { get; }

    public async ValueTask<ISegmentReadResult> TryReadAsync(ReadOnlySequence<byte> buffer)
    {
        var result = Read(buffer);
        if (result.status == SegmentationStatus.Complete)
        {
            if (result.segment == null) throw new NotSupportedException("\"Valid\" segmentation without data is not possible");

            await OnSegmentReceived(result.segment.Value);
            buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End));
        }
        else if (result.status == SegmentationStatus.Invalid && Options.HasFlag(SegmentionOptions.SkipInvalidSegment))
        {
            if (result.segment != null)
            {
                buffer = buffer.Slice(buffer.GetPosition(0, result.segment.Value.End)); //Assume this end marks the second start for next segment
            }
            else
            {
                buffer = buffer.Slice(buffer.GetPosition(0, buffer.End)); // if segment isn't provided just fast forward to end
            }

            return new SegmentReadResult(SegmentationStatus.Complete, buffer);
        }

        return new SegmentReadResult(result.status, buffer);
    }

    protected abstract (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer);
}