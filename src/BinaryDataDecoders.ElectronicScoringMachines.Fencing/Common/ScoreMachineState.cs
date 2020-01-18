using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    public class ScoreMachineState : IScoreMachineState
    {
        public static readonly IScoreMachineState Empty = new ScoreMachineState(default, default, default);

        public ScoreMachineState(Fencer red, Fencer green, TimeSpan clock)
        {
            Red = red;
            Green = green;
            Clock = clock;
        }

        public Fencer Red { get; }
        public Fencer Green { get; }
        public TimeSpan Clock { get; }

        public override string ToString()
        {
            return $"R:{Red} G:{Green} T:{Clock}";
        }

        public override bool Equals(object obj)
        {
            return obj is IScoreMachineState i && Red.Equals(i.Red) && Green.Equals(i.Green) && Clock.Equals(i.Clock);
        }

        public override int GetHashCode()
        {
            return (Red, Green, Clock).GetHashCode();
        }
    }
}
