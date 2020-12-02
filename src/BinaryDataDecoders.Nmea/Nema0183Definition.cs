using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.Segmenters;
using BinaryDataDecoders.IO.UsbHids;
using System.ComponentModel;
using System.Composition;
using static BinaryDataDecoders.IO.Bytes;

namespace BinaryDataDecoders.Nmea
{
    [SerialPort(4800)]
    [UsbHid(0x1163, 0x200)]
    [Description("NEMA 0183")]
    [Export(typeof(IDeviceDefinition))]
    public class Nema0183Definition : IDeviceDefinitionReceiver<INema0183Message>
    {
        public ISegmentBuildDefinition SegmentDefintion => Segment.StartsWith(_S, _E).AndEndsWith(Lf);
        public IMessageDecoder<INema0183Message> Decoder { get; } = new Nema0183Decoder();
    }
}
