using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    public class ScoreMachineState : IScoreMachineState
    {
        public static readonly IScoreMachineState Empty = new ScoreMachineState(default, default, default, default);

        /// <summary>
        /// </summary>
        /// <param name="left">Left</param>
        /// <param name="right">Right</param>
        /// <param name="clock"></param>
        public ScoreMachineState(Fencer left, Fencer right, TimeSpan clock, byte match)
        {
            Left = left;
            Right = right;
            Clock = clock;
        }

        public Fencer Left { get; }
        public Fencer Right { get; }
        public TimeSpan Clock { get; }
        public byte Match { get; }

        public override string ToString()
        {
            return $"R:{Left} G:{Right} T:{Clock} M:{Match}";
        }

        public override bool Equals(object obj)
        {
            return obj is IScoreMachineState i && Left.Equals(i.Left) && Right.Equals(i.Right) && Clock.Equals(i.Clock) && Match.Equals(i.Match);
        }

        public override int GetHashCode()
        {
            return (Left, Right, Clock).GetHashCode();
        }
    }
}
