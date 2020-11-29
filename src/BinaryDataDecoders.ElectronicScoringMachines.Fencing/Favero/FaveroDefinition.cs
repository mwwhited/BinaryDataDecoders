using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Ports;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Favero
{
    [SerialPort(2400, Parity.None, 8, StopBits.One)]
    public class FaveroDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
    {
        public ISegmentBuildDefinition SegmentDefintion { get; } =
            Segment.StartsWith(0xff)
                   .AndIsLength(10)
                   .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);

        public IMessageDecoder<IScoreMachineState> Decoder { get; } = new FaveroDecoder();
    }
}
