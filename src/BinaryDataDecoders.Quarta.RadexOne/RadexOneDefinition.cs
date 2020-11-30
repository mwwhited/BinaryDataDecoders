using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.ToolKit;
using System.ComponentModel;

namespace BinaryDataDecoders.Quarta.RadexOne
{
    [SerialPort(9600)]
    [Description("Radex One")]
    public class RadexOneDefinition : IDeviceDefinitionTransmitter<IRadexObject>, IDeviceDefinitionReceiver<IRadexObject>
    {
        public IMessageEncoder<IRadexObject> Encoder { get; } = new MessageEncoder<IRadexObject>();

        public ISegmentBuildDefinition SegmentDefintion { get; } =
            Segment.StartsWith(0x7a)
                   .AndIsLength(12)
                   .ExtendedWithLengthAt<ushort>(4, Endianness.Little)
                   .WithOptions(SegmentionOptions.SkipInvalidSegment);

        public IMessageDecoder<IRadexObject> Decoder { get; } = new RadexOneDecoder();
    }
}
