using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.IO.Segmenters;
using System.ComponentModel;
using System.Composition;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero
{
    [SerialPort(2400, Parity.None, 8, StopBits.One)]
    [Description("Favero")]
    [Export(typeof(IDeviceDefinition))]
    public class FaveroDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
    {
        public ISegmentBuildDefinition SegmentDefintion { get; } =
            Segment.StartsWith(0xff)
                   .AndIsLength(10)
                   .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);

        public IMessageDecoder<IScoreMachineState> Decoder { get; } = new FaveroDecoder();
    }
}
