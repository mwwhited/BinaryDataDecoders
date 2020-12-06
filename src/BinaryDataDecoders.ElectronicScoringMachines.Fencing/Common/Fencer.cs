using System.Diagnostics;

namespace BinaryDataDecoders.ElectronicScoringMachines.Fencing.Common
{
    [DebuggerDisplay("S{Score} L{Lights} C{Cards} P{Priority}")]
    public struct Fencer
    {
        public Fencer(byte score, Cards cards, Lights lights, bool priority)
        {
            Score = score;
            Cards = cards;
            Lights = lights;
            Priority = priority;
        }

        public byte Score { get; }
        public Cards Cards { get; }
        public Lights Lights { get; }
        public bool Priority { get; }

        public override string ToString() => $"S>{Score:000} L>{Lights} C>{Cards} P>{Priority}";
        public override bool Equals(object obj) => obj switch
        {
            Fencer i => Score == i.Score && Cards == i.Cards && Lights == i.Lights && Priority == i.Priority,
            _ => false
        };
        public override int GetHashCode() => (Score, Cards, Lights, Priority).GetHashCode();
        public static bool operator ==(Fencer left, Fencer right) => left.Equals(right);
        public static bool operator !=(Fencer left, Fencer right) => !(left == right);
    }
}