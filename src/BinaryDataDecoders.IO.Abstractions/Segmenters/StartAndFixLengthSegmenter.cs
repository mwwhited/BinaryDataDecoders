using System;
using System.Buffers;
using System.Linq;

namespace BinaryDataDecoders.IO.Segmenters;

public sealed class StartAndFixLengthSegmenter(
    OnSegmentReceived onSegmentReceived,
    byte[] starts,
    long fixedLength,
    SegmentionOptions options,
    SegmentExtensionDefinition? extensionDefinition = null) : SegmenterBase(onSegmentReceived, options)
{
    public byte[] Starts { get; } = starts;
    public long FixedLength { get; } = fixedLength;
    public SegmentExtensionDefinition? ExtensionDefinition { get; } = extensionDefinition;

    protected override (SegmentationStatus status, ReadOnlySequence<byte>? segment) Read(ReadOnlySequence<byte> buffer)
    {
        var startOfSegment = Starts.Select(start => buffer.PositionOf(start)).FirstOrDefault(start => start != null);
        if (startOfSegment != null)
        {
            var segment = buffer.Slice(startOfSegment.Value);
            if (segment.Length >= FixedLength)
            {
                var completeSegment = segment.Slice(0, buffer.GetPosition(FixedLength, startOfSegment.Value));

                if (this.Options.HasFlag(SegmentionOptions.SecondStartInvalid))
                {
                    var secondStart = Starts.Select(start => completeSegment.PositionOf(start)).FirstOrDefault(start => start != null);
                    if (secondStart != null)
                    {
                        // Second start detected
                        return (SegmentationStatus.Invalid, buffer.Slice(0, secondStart.Value));
                    }
                }

                if (ExtensionDefinition != null)
                {
                    var valueData = completeSegment.Slice(ExtensionDefinition.Postion, ExtensionDefinition.Length);
                    //TODO, drop the endian check... only support little and convert 
                    var set = this.ExtensionDefinition.Endianness == Endianness.Little ? valueData.ToArray() : valueData.ToArray().Reverse().ToArray();

                    ulong extendedLength = 0;
                    for (var i = 0; i < this.ExtensionDefinition.Length; i++)
                    {
                        extendedLength |= (ulong)set[i] << (8 * i);
                    }

                    var actualLength = FixedLength + (long)extendedLength;

                    if (segment.Length < actualLength)
                    {
                        return (SegmentationStatus.Incomplete, buffer);
                    }

                    completeSegment = segment.Slice(0, buffer.GetPosition(actualLength, startOfSegment.Value));
                }

                return (SegmentationStatus.Complete, completeSegment);
            }
        }
        else if (buffer.Length > this.FixedLength)
        {
            var leftover = buffer.Length % this.FixedLength;
            buffer = buffer.Slice(0, buffer.GetPosition(-leftover, buffer.End));
            return (SegmentationStatus.Invalid, buffer);
        }

        return (SegmentationStatus.Incomplete, buffer);
    }
}