using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    public interface IParseScoreMachineState
    {
        IScoreMachineState Parse(ReadOnlySpan<byte> frame);
    }
}
