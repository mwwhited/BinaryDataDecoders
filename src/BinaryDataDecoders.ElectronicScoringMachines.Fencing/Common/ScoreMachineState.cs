using System;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common;

/// <summary>
/// </summary>
/// <param name="left">Left</param>
/// <param name="right">Right</param>
/// <param name="clock"></param>
public class ScoreMachineState(Fencer left, Fencer right, TimeSpan clock, byte match) : IScoreMachineState
{
    public static readonly IScoreMachineState Empty = new ScoreMachineState(default, default, default, default);

    public Fencer Left { get; } = left;
    public Fencer Right { get; } = right;
    public TimeSpan Clock { get; } = clock;
    public byte Match { get; } = match;

    public override string ToString() => $"R:{Left} G:{Right} T:{Clock} M:{Match}";

    public override bool Equals(object obj) => obj switch
    {
        IScoreMachineState i => Left.Equals(i.Left) && Right.Equals(i.Right) && Clock.Equals(i.Clock) && Match.Equals(i.Match),
        _ => false
    };

    public override int GetHashCode() => (Left, Right, Clock).GetHashCode();
}
