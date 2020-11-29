using BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;
using BinaryDataDecoders.IO;
using BinaryDataDecoders.IO.Messages;
using BinaryDataDecoders.IO.Pipelines;
using BinaryDataDecoders.IO.Pipelines.Definitions;
using BinaryDataDecoders.IO.Ports;
using BinaryDataDecoders.ToolKit;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.SaintGeorge
{
    [SerialPort(9600, Parity.None, 8, StopBits.One)]
    public class SgStateDefinition : IDeviceDefinitionReceiver<IScoreMachineState>
    {
        public ISegmentBuildDefinition SegmentDefintion { get; } =
            Segment.StartsWith(ControlCharacters.StartOfHeading)
                   .AndEndsWith(ControlCharacters.EndOfTransmission)
                   .WithMaxLength(100)
                   .WithOptions(SegmentionOptions.SkipInvalidSegment | SegmentionOptions.SecondStartInvalid);

        public IMessageDecoder<IScoreMachineState> Decoder { get; } = new SgStateDecoder();
    }
}