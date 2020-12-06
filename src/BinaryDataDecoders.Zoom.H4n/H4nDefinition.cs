using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.Segmenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Composition;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static BinaryDataDecoders.Zoom.H4n.H4nStatus;

namespace BinaryDataDecoders.Zoom.H4n
{
    [SerialPort(2400)] //, ReadTimeout = 500, WriteTimeout = 500)]
    [Description("Zoom H4N")]
    [Export(typeof(IDeviceDefinition))]
    public class H4nDefinition :
        IDeviceDefinitionReceiver<IH4nMessage>,
        IDeviceDefinitionTransmitter<IH4nMessage>,
        IDeviceDefinitionInitialize
    {
        public ISegmentBuildDefinition SegmentDefintion { get; } =
            Segment.StartsWithMask((byte)(Record | Peak | Mic | Led1 | Led2))
                   .AndIsLength(1)
                   .WithOptions(SegmentionOptions.SkipInvalidSegment);

        public IMessageDecoder<IH4nMessage> Decoder { get; } = new H4nDecoder();

        public IMessageEncoder<IH4nMessage> Encoder { get; } = new MessageEncoder<IH4nMessage>();

        public async Task InitializeAsync(IDeviceAdapter device, CancellationToken token)
        {
            try
            {
                var stream = device.Stream;

                var buffered = device as IBufferedDeviceAdapter;
                //TODO: this is getting stuck... need to change from stream to IDeviceStream and expose bytes to read.
                //TODO: should have a max counter and exception if triggered
                do
                {
                    do
                    {
                        stream.WriteByte(0x00);
                        await stream.FlushAsync(token);
                        await Task.Delay(30);
                       // var bytes = buffered.BytesToRead;
                    }
                    while ( buffered.BytesToRead < 4); //!token.IsCancellationRequested &&

                   // if (token.IsCancellationRequested) break;

                    var buffer = new byte[buffered.BytesToRead];
                    var result = await stream.ReadAsync(buffer, token);

                    if (buffer.Any(b => (0x7f & b) > 0)) break;
                   // if (token.IsCancellationRequested) break;

                    stream.WriteByte(0xa1);
                    await stream.FlushAsync(token);
                    stream.WriteByte(0x80);
                    await stream.FlushAsync(token);
                    stream.WriteByte(0x00);
                    await stream.FlushAsync(token);
                } while (!token.IsCancellationRequested);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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
