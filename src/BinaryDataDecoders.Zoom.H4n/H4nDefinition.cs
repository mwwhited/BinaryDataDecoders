using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.Segmenters;
using System.ComponentModel;
using System.Composition;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static BinaryDataDecoders.Zoom.H4n.H4nStatus;

namespace BinaryDataDecoders.Zoom.H4n;

[SerialPort(2400)]
[Description("Zoom H4N")]
[Export(typeof(IDeviceDefinition))]
public class H4nDefinition :
    IDeviceDefinitionReceiver<IH4nMessage>,
    IDeviceDefinitionTransmitter<IH4nMessage>,
    IDeviceDefinitionInitialize
{
    private readonly int _maxInitCount = 1024;
    public ISegmentBuildDefinition SegmentDefintion { get; } =
        Segment.StartsWithMask((byte)(Record | Peak | Mic | Led1 | Led2))
               .AndIsLength(1)
               .WithOptions(SegmentionOptions.SkipInvalidSegment);

    public IMessageDecoder<IH4nMessage> Decoder { get; } = new H4nDecoder();

    public IMessageEncoder<IH4nMessage> Encoder { get; } = new MessageEncoder<IH4nMessage>();

    public async Task InitializeAsync(IDeviceAdapter device, CancellationToken token)
    {
        var stream = device.Stream;
        var buffered = device as IBufferedDeviceAdapter;
        var maxInitCount = _maxInitCount;
        do
        {
            do
            {
                maxInitCount--;
                stream.WriteByte(0x00);
                await stream.FlushAsync(token);
                await Task.Delay(30);

                if (maxInitCount < 0) throw new IOException($"Unable to Initialize {nameof(H4nDefinition)}");
            }
            while (!token.IsCancellationRequested && buffered.BytesToRead < 4);

            var buffer = new byte[buffered.BytesToRead];
            var result = await stream.ReadAsync(buffer, token);

            if (buffer.Any(b => (0x7f & b) > 0)) break;

            stream.WriteByte(0xa1);
            await stream.FlushAsync(token);
            stream.WriteByte(0x80);
            await stream.FlushAsync(token);
            stream.WriteByte(0x00);
            await stream.FlushAsync(token);
        } while (!token.IsCancellationRequested);
    }
}
