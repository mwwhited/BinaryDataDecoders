using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    public interface IScoreMachineState
    {
        Fencer Red { get; }
        Fencer Green { get; }
        TimeSpan Clock { get; }
    }
}