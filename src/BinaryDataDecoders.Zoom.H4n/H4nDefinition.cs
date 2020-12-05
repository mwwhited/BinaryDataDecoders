using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.Segmenters;
using System.ComponentModel;
using System.Composition;

namespace BinaryDataDecoders.Zoom.H4n
{
    [SerialPort(2400)]
    [Description("Zoom H4N")]
    [Export(typeof(IDeviceDefinition))]
    public class H4nDefinition :
        IDeviceDefinitionReceiver<IH4nMessage>,
        IDeviceDefinitionTransmitter<IH4nMessage>
    {
        #region IDeviceDefinitionReceiver<IH4nMessage>

        public ISegmentBuildDefinition SegmentDefintion { get; } =
            Segment.StartsWithMask(0x7f)
                   .AndIsLength(1)
                   .WithOptions(SegmentionOptions.SkipInvalidSegment);

        public IMessageDecoder<IH4nMessage> Decoder { get; } = new H4nDecoder();

        #endregion IDeviceDefinitionReceiver<IH4nMessage>

        #region IDeviceDefinitionTransmitter<IH4nMessage>

        public IMessageEncoder<IH4nMessage> Encoder { get; } = new MessageEncoder<IH4nMessage>();

        #endregion IDeviceDefinitionTransmitter<IH4nMessage>

        //send request, pause 100ms, send poll
        //Record: 0x81 0x00 | 0x80 0x00
        //Play:   0x82 0x00 | 0x80 0x00
        //Stop:   0x84 0x00 | 0x80 0x00
        //ffwd:   0x88 0x00 | 0x80 0x00
        //rwd:    0x90 0x00 | 0x80 0x00
        //vol+:   0x80 0x08 | 0x80 0x00
        //vol-:   0x80 0x10 | 0x80 0x00
        //rec+:   0x80 0x20 | 0x80 0x00
        //rec-:   0x80 0x40 | 0x80 0x00
        //mic :   0x80 0x01 | 0x80 0x00
        //ch1 :   0x80 0x02 | 0x80 0x00
        //ch2 :   0x80 0x04 | 0x80 0x00
    }
}
